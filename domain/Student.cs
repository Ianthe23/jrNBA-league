public class Student : Entity<int> {
    public string Name { get; set; }
    public string School { get; set; }

    public Student(string name, string school) : base() {
        this.Name = name;
        this.School = school;
    }

    public Student() : base() {}

    public override string ToString() {
        return $"{this.Name} - {this.School}";
    }

    public override bool Equals(object obj) {
        if (obj == null || GetType() != obj.GetType()) {
            return false;
        }

        Student student = (Student)obj;
        return this.Id.Equals(student.Id) && this.Name.Equals(student.Name) && this.School.Equals(student.School);
    }

    public override int GetHashCode() {
        return HashCode.Combine(this.Id, this.Name, this.School);
    }
}