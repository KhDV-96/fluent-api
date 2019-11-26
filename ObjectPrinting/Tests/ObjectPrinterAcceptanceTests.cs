﻿using System;
using System.Globalization;
using NUnit.Framework;

namespace ObjectPrinting.Tests
{
    [TestFixture]
    public class ObjectPrinterAcceptanceTests
    {
        [Test]
        public void Demo()
        {
            var person = new Person {Name = "Alex", Age = 19, Height = 170};

            var printer = ObjectPrinter.For<Person>()
                //1. Исключить из сериализации свойства определенного типа
                .Excluding<Guid>()
                //2. Указать альтернативный способ сериализации для определенного типа
                .Printing<DateTime>().Using(d => d.ToString(CultureInfo.CurrentCulture))
                //3. Для числовых типов указать культуру
                .Printing<int>().Using(CultureInfo.CurrentCulture)
                //4. Настроить сериализацию конкретного свойства
                .Printing(p => p.Id).Using(p => p.ToString())
                //5. Настроить обрезание строковых свойств (метод должен быть виден только для строковых свойств)
                .Printing(p => p.Name).TrimmedToLength(20)
                //6. Исключить из сериализации конкретного свойства
                .Excluding(p => p.Age);

            printer.PrintToString(person);

            //7. Синтаксический сахар в виде метода расширения, сериализующего по-умолчанию
            person.PrintToString();
            //8. ...с конфигурированием
            person.PrintToString(p => p.Excluding<string>());
        }
    }
}