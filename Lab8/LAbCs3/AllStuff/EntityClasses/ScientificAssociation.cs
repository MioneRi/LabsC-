using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace LAbCs3
{
    public class ScientificAssociation<T> : IEntity, IJournal
    {        
        private string title;
        private int associationID;
        private string studyArea;
        private string typeOfAssociation;
        private TypeOfEntity typeOfEntity;

        private List<T> membersArray = new List<T>();

        public ScientificAssociation(TypeOfEntity typeOfEntity)
        {
            this.typeOfEntity = typeOfEntity;

            associationID = membersArray.Count;
            switch (typeOfEntity)
            {
                case TypeOfEntity.Employee:
                    {
                        typeOfAssociation = "Преподавательское";
                    }
                    break;

                case TypeOfEntity.Student:
                    {
                        typeOfAssociation = "Студенческое";
                    }
                    break;
            }
            
        }

        public int ActualNumberOfParticipants => membersArray.Count;

        public string TypeOfAssociation => typeOfAssociation;

        public int AssociationID => associationID;

        public string Title => title;

        public string StudyArea => studyArea;        

        public void SetInfo()
        {
            //-------------------------------
            Write("Название обьединения : ");

            title = MainActions.GetCorrectString();

            //-------------------------------
            Write("Изучаемая область : ");

            studyArea = MainActions.GetCorrectString();

        }

        public void ShowInfo()
        {
            // By pattern (AssociationID, TypeOfAssociation, Title, StudyArea )

            WriteLine(AssociationID + "\t" + TypeOfAssociation + "\t" + Title + "\t" + StudyArea );

        }

        public IEnumerator GetEnumerator()
        {
            return membersArray.GetEnumerator();
        }

        public void Add(T ourParticipant)
        {
            membersArray.Add(ourParticipant);
        }

        public void Remove(T ourParticipant)
        {
            membersArray.Remove(ourParticipant);
        }

        public void ShowParticipants() //тут ошибка!
        {
            bool flag = false;

            WriteLine("(AssociationID, TypeOfAssociation, Title, StudyArea )");

            ShowInfo();

            if (typeOfEntity == TypeOfEntity.Student)
            {
                WriteLine("(ID студента, Факультет, Группа, Имя, Фамилия, Успеваемость)");
            }
            else if (typeOfEntity == TypeOfEntity.Employee)
            {
                WriteLine("(ID работника, Имя, Фамилия, Должность, Стаж)");
            }
            

            for (var i = 0; i < ActualNumberOfParticipants; i++)
            {
                if (membersArray[i] != null)
                {                    
                    if (typeOfEntity == TypeOfEntity.Student)
                    {
                        //Student ourStuedent = membersArray[i] as Student;
                        MainActions.ShowStudentInfo(membersArray[i] as Student);
                    }
                    else if (typeOfEntity == TypeOfEntity.Employee)
                    {
                        //Employee ourEmployee = membersArray[i] as Employee;
                        MainActions.ShowEmployeeInfo(membersArray[i] as Employee);
                    }
                    
                    flag = true;
                }
            }

            MainActions.NoExistMassege(flag, TypeOfEntity.Student, AmountOfEntities.Several);
        }

    }
}
