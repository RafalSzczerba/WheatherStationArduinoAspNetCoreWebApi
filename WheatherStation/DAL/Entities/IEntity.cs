﻿namespace WheatherStation.DAL.Entities
{
    public interface IEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
    }
}
