﻿using Microsoft.AspNetCore.Identity;

namespace Domain;

public class UserEntity : IdentityUser
{
    public virtual List<TaskEntity> Tasks { get; set; }
}