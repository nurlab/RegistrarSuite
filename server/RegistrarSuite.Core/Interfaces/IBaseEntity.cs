﻿namespace RegistrarSuite.Core.Interfaces
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        bool IsDeleted { get; set; }
        bool IsActive { get; set; }
    }
}
