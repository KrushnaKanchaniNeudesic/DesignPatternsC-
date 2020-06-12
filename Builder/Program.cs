using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices.ComTypes;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            FacadePersonBuilder.TestBuilder();

            ICollection<SqlParameter> collection = new FluentbuilderSqlParameter(new List<SqlParameter>())
                                                        .Add("test", "test")
                                                        .Add("test", "test")
                                                        .parameters;


            var person = Person.New.Called("krushna").WorkAsA("Soft").Build();
            Console.WriteLine(person);
            Console.ReadKey();
        }



        public class Person
        {
            public string Name { get; set; }

            public string Position { get; set; }

            public static Builder New => new Builder();

            public class Builder: PerosnJobBuilder<Builder>
            {

            }

            public override string ToString()
            {
                return Name;
            }
        }

        public abstract class PersonBuilder
        {
            protected Person person = new Person();

            public Person Build() => person; 

        }

        public class PerosnInfoBuilder<Self> : PersonBuilder 
            where Self : PerosnInfoBuilder<Self> 
        {

            public Self Called(string name)
            {
                person.Name = name;
                return (Self)this;
            }
        }

        public class PerosnJobBuilder<Self>: PerosnInfoBuilder<PerosnJobBuilder<Self>>
            where Self: PerosnJobBuilder<Self>
             
        {
            public Self WorkAsA(string postion)
            {
                person.Position = postion;
                return (Self) this;
            }
        }
    }
}
