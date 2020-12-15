using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lib
{
    public class StudGroup:IEnumerable
    {
        public List<Student> Students { get; private set; } = new List<Student>();
        /// <summary>
        /// Ищет первый элемент со значением свойства prop равным value
        /// </summary>
        /// <param name="value">Сравниваемое значение</param>
        /// <param name="prop">Имя свойства</param>
        /// <returns>Student если найдено совпадение, null если совпадений нет</returns>
        public Student Search(object value, string prop = "FullName")
        {
            if (value is null)
            {
                throw new ArgumentNullException($"{nameof(value)} is null");
            }

            if (string.IsNullOrEmpty(prop))
            {
                throw new ArgumentException($"Invalid argument {nameof(prop)}");
            }

            try
            {
                // Возможно он спросит почему ты так сделал, ниже я расписал почему

                // Можно было создать несколько методов сортировки SortBy...,
                // но это значит - больше кода - больше потенциальных ошибок.
                // Еще вариант передать компаратор, но писать отдельный класс/функицю 
                // для отдельной сортировки свойств простого объекта - слишком нудно
                return Students.First(
                        i => i.
                        GetType().         // Получяем объект Type 
                        GetProperty(prop). // получаем информацию о свойстве
                        GetValue(i).       // получаем значение свойства объекта
                        Equals(value)      // сравниваем его с value
                    );
            }
            catch (InvalidOperationException e)
            {

                if (e.Message == "Sequence contains no matching element")
                {
                    return null;
                }

                else
                {
                    throw e;
                }

            }

        }

        public void Sort()
        {
            // Сортировка по полю Brithday
            Students = Students.OrderBy(i => i.Birthday).ToList();
        }

        public void Add(Student student)
        {
            Students.Add(student);
        }

        public void Add(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                Students.Add(student);
            }
        }

        public bool Remove(Student student)
        {
            return Students.Remove(student);
        }

        public IEnumerator GetEnumerator()
        {
            return Students.GetEnumerator();
        }

        public override string ToString()
        {
            string res = "";
            foreach (var student in this)
            {
                res += student.ToString()+'\n';
            }
            return res;
        }
    }
}
