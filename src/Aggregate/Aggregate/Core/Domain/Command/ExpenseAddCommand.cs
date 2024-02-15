namespace Aggregate.Core.Domain.Command;

public record ExpenseAddCommand(string Title, float Payment, long ActivityId);