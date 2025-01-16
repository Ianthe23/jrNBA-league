// represent references to methods with a specific signature. 
// they enable to pass methods as arguments, assign them to variables, and invoke them dynamically.

public delegate E LineToEntity<E>(string line);
public delegate string EntityToLine<E>(E entity);

public class InFileRepo<ID, E> : InMemoryRepository<ID, E> where E : Entity<ID> 
{
    private string _filePath;
    private LineToEntity<E> _lineToEntity;
    private EntityToLine<E> _entityToLine;

    public InFileRepo(string filePath, LineToEntity<E> lineToEntity, EntityToLine<E> entityToLine)
    {
        _filePath = filePath;
        _lineToEntity = lineToEntity;
        _entityToLine = entityToLine;
        loadFromFile();
    }

    private void loadFromFile()
    {
        List<E> entities = LoadFromFile(_filePath, _lineToEntity);
        foreach (var entity in entities)
        {
            base.Add(entity);
        }
    }

    protected List<T> LoadFromFile<T>(string filePath, LineToEntity<T> lineToEntity)
    {
        var lines = File.ReadAllLines(filePath);
        List<T> entities = new List<T>();
        foreach (var line in lines)
        {
            var entity = lineToEntity(line);
            entities.Add(entity);
        }
        return entities;
    }

    private void WriteToFile()
    {
        var lines = Entities.Values.Select(entity => _entityToLine(entity));
        File.WriteAllLines(_filePath, lines);
    }

    public override E? Add(E entity)
    {
        var result = base.Add(entity);
        if (result != null)
        {
            WriteToFile();
        }
        return result;
    }

    public override E? Delete(ID id)
    {
        var result = base.Delete(id);
        if (result != null)
        {
            WriteToFile();
        }
        return result;
    }

    public override E Update(E entity)
    {
        var result = base.Update(entity);
        if (result != null)
        {
            WriteToFile();
        }
        return result;
    }
}