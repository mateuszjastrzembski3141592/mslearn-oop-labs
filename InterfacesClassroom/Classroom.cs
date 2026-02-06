using System;
using System.Collections;
using System.Collections.Generic;

namespace InterfacesClassroom;

public class Classroom :IEnumerable<Student>
{
    private List<Student> students = [];

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public void SortStudentsByAge()
    {
        students.Sort(); // Uses the IComparable implementation (CompareTo()) in Student class
    }

    public IEnumerator<Student> GetEnumerator()
    {
        return students.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
