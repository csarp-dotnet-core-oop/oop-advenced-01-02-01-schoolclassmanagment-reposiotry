﻿using SchoolClassManagmentProject.Models.AppExceptions;
using SchoolClassManagmentProject.Models.Entities;
using SchoolClassManagmentProject.Repos;

SchoolClass schoolClass9a = new SchoolClass(9, 'a',12);
SchoolClass schoolClass9b = new SchoolClass(9, 'b',13);
SchoolClass schoolClass10a = new SchoolClass(10, 'a', 12);
SchoolClass schoolClass10b = new SchoolClass(10, 'b', 12);

SchoolClass schoolClass12a = new SchoolClass(12, 'a', 12);
SchoolClass schoolClass12b = new SchoolClass(12, 'b', 12);

SchoolClass schoolClass13a = new SchoolClass(13, 'a',13);
SchoolClass schoolClass13b = new SchoolClass(13, 'b',13);

try
{
    schoolClass9a.SetLastGrade(1);
}
catch (LastGradeModificationErrorException lastGradeModificationError)
{
    Console.WriteLine(lastGradeModificationError.ParamName);
    Console.WriteLine(lastGradeModificationError.Message);
}

schoolClass9a.AdvanceGrade();
Console.WriteLine(schoolClass9a.Name);

SchoolClassRepo schoolClassRepo = new SchoolClassRepo();
schoolClass10b.SetClassMoney(1500);
schoolClassRepo.Add(schoolClass9a);
schoolClassRepo.Add(schoolClass9b);
schoolClassRepo.Add(schoolClass10a);
schoolClassRepo.Add(schoolClass10b);
schoolClassRepo.Add(schoolClass12a);
schoolClassRepo.Add(schoolClass12b);
schoolClassRepo.Add(schoolClass13a);
schoolClassRepo.Add(schoolClass13b);

Console.WriteLine($"Iskolában az osztályok száma: {schoolClassRepo.NumberOfSchoolClasses}");
Console.WriteLine($"Iskolában a végzős osztályok száma: {schoolClassRepo.NumberOfGraduateClasses}");

schoolClassRepo.Remove(10, 'b');

Console.WriteLine($"Iskolában az osztályok száma: {schoolClassRepo.NumberOfSchoolClasses}");

Console.WriteLine("9. évfolyamoksok:");
List<SchoolClass> schoolClasses9 = schoolClassRepo.GetSchoolClasses(9);
foreach (SchoolClass schoolClass in schoolClasses9)
    Console.WriteLine($"{schoolClass.Name}");

Console.WriteLine(schoolClassRepo.GetNumberOfSchoolClassesPerGrade(9));

Console.WriteLine("Végzős osztályok:");
List<SchoolClass> gradeteClasses=schoolClassRepo.GetGraduateClasses();
foreach(SchoolClass graduateClass in gradeteClasses)
    Console.WriteLine($"{graduateClass.Name}");

Console.WriteLine("Évfolyamok:");
List<byte> grades = schoolClassRepo.GetGrades();
foreach (byte garade in grades)
    Console.WriteLine(garade);

schoolClass12a.SetClassMoney(10000);
int exsistingClassClassMoneyPerStudentInOneYear = schoolClassRepo.GetClassMoneyPerStudentInOneYear(12, 'a');
Console.WriteLine($"10.a osztáybevétele egy évben egy diák által:{exsistingClassClassMoneyPerStudentInOneYear}");

int nonExsistingClassClassMoneyPerStudentInOneYear = schoolClassRepo.GetClassMoneyPerStudentInOneYear(255, 'z');
Console.WriteLine($"10.a osztáybevétele egy évben egy diák által:{nonExsistingClassClassMoneyPerStudentInOneYear}");

