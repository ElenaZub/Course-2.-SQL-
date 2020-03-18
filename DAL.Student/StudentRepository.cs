using DALStudent;
using DALStudent.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Student
{
    public class StudentRepository : IStudentRepository, IDisposable
    {
        private UniversityDbContext context;
        private bool disposed = false;

        public StudentRepository(UniversityDbContext context)
        {
            this.context = context;
        }

        IEnumerable<DALStudent.Model.Student> IStudentRepository.GetStudents()
        {
            return this.context.Students.ToList();
        }

        DALStudent.Model.Student IStudentRepository.GetStudentById(int studentId)
        {
            return this.context.Students.Find(studentId);
        }

        public void InsertStudent(DALStudent.Model.Student student)
        {
            this.context.Students.Add(student);
        }

        public void DeleteStudent(int studentId)
        {
            DALStudent.Model.Student student = this.context.Students.Find(studentId);
            this.context.Students.Remove(student);
        }

        public void UpdateStudent(DALStudent.Model.Student student)
        {
            this.context.Entry(student).State = EntityState.Modified;
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    this.context.Dispose();

            this.disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}