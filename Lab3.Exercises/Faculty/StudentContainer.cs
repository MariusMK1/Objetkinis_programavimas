using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculty
{
    internal class StudentContainer
    {
        private Student[] students;
        public int Count { get; private set; }
        public StudentContainer()
        {
            this.students = new Student[16]; //default capacity
        }
        public string FacultyName { get; set; }
        public void Add(Student student)
        {
            if (this.Count == this.Capacity) // Container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.students[this.Count++] = student;
        }
        public void Put(int i, Student student)
        {
            this.Put(i, student);       //Overides an element in the collection at the specified index.
        }
        public void Insert(int index, Student student)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            for (int i = this.Count; i > index; i--)
            {
                this.students[i] = this.students[i - 1];
            }
            this.students[index] = student;    //Inserts an element into the collection at the specified index.
            this.Count++;
        }
        public void Remove(Student student)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.students[i].Equals(student))
                {
                    for (int j = i; j < Count; j++)
                    {
                        this.students[j] = this.students[j + 1];
                    }
                    Count--;
                }
            }
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                this.students[i] = this.students[i + 1];
            }
            Count--;
        }
        public Student Get(int index)
        {
            return this.students[index];
        }
        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Student a = this.students[i];
                    Student b = this.students[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        this.students[i] = b;
                        this.students[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        public bool Contains(Student student)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.students[i].Equals(student))
                {
                    return true;
                }
            }
            return false;
        }
        private int Capacity;
        public StudentContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.students = new Student[capacity];
        }
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Student[] temp = new Student[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.students[i];
                }
                this.Capacity = minimumCapacity;
                this.students = temp;
            }
        }
        public StudentContainer(StudentContainer container) : this() //Calls another constructor
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public StudentContainer Intersect(StudentContainer other)
        {
            StudentContainer result = new StudentContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Student current = this.students[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
    }
}
