﻿using System;

namespace ObjectPrinting.Tests
{
    public class Person
    {
        public string Phone;
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }
        public Person BestFriend { get; set; }
    }
}