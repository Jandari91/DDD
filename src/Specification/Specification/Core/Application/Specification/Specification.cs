﻿using Domain.Entity;
using System.Linq.Expressions;

namespace Specification.Core.Application.Specification;

public abstract class Specification<T> where T : BaseEntity
{
    public abstract Expression<Func<T, bool>> ToExpression();

    public bool IsSatisfiedBy(T entity)
    {
        Func<T, bool> predicate = ToExpression().Compile();
        return predicate(entity);
    }

    public Specification<T> And(Specification<T> specification)
    {
        return new AndSpecification<T>(this, specification);
    }
}

public class AndSpecification<T> : Specification<T> where T : BaseEntity
{
    private readonly Specification<T> _left;
    private readonly Specification<T> _right;

    public AndSpecification(Specification<T> left, Specification<T> right)
    {
        _right = right;
        _left = left;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        Expression<Func<T, bool>> leftExpression = _left.ToExpression();
        Expression<Func<T, bool>> rightExpression = _right.ToExpression();

        BinaryExpression andExpression = Expression.AndAlso(
            leftExpression.Body, rightExpression.Body);

        return Expression.Lambda<Func<T, bool>>(
            andExpression, leftExpression.Parameters.Single());
    }
}