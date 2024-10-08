﻿namespace Ordering.Domain.ValueObjects
{
    public record ProductId
    {
        public Guid Value { get; }

        private ProductId(Guid id) => Value = id;

        public static ProductId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainExcepetion("ProductId cannot be empty.");
            }

            return new ProductId(value);
        }

    }
}
