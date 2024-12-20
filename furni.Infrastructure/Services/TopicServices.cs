﻿using furni.Domain.Entities;
using furni.Infrastructure.Data;
using furni.Infrastructure.IServices;

namespace furni.Infrastructure.Services
{
    public class TopicServices(ApplicationDbContext context) : RepositoryAsync<Topic>(context), ITopicServices { }
}
