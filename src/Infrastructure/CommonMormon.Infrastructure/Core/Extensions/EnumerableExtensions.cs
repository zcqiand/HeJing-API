﻿// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

namespace CommonMormon.Infrastructure.Core.Extensions;

public static class EnumerableExtensions
{
    public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> query, bool condition, Func<T, bool> predicate)
    {
        return condition
            ? query.Where(predicate)
            : query;
    }

    public static IEnumerable<T> TakeIf<T, TKey>(this IEnumerable<T> query, Func<T, TKey> orderBy, bool condition, int limit, bool orderByDescending = true)
    {
        // It is necessary sort items before it
        query = orderByDescending ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);

        return condition
            ? query.Take(limit)
            : query;
    }
}