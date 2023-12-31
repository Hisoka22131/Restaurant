﻿using Core.Domain;
using Core.RepositoryPattern.GenericRepository;

namespace Core.RepositoryPattern.CustomRepository.Interfaces;

public interface IDishesOrderRepository : IGenericRepository<DishOrder>
{
    DishOrder GetDishesOrder(int id);
}