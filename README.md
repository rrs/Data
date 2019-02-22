Rrs.Data
========
A simple library to minimise code bloat from repetitive database access code. For use with other libraries or code that relies on IDbConnection and IDbTransaction

Usage
-----

# IDbConnectionFactory

Requires an implementation of IDbConnectionFactory

[Sql Server Implementation](https://github.com/rrs/DataSqlServer)

# Function Signatures

Once you have an instance of IDbDelegator you can call .Execute on it. It accepts a minimum set of function signatures to be able to do all the necessary db access you might require.

## Non transactional

### Action<IDbConnection>
 
 Any void function with a parameter of IDbConnection

```
public void ExampleSectionOfCode()
{
    ... useful stuff
    db.Execute(UpdateUserRecordLastAccessed);
    ...
}

...

private void UpdateUserRecordLastAccessed(IDbConnection c)
{
    ... use IDbConnection
}

```

### Action<IDbConnection, T>

 Any void function with a parameter of IDbConnection and a second paramter of type T

```
public void ExampleSectionOfCode()
{
    ... useful stuff
    db.Execute(UpdateUserRecordLastAccessed, DateTime.Now);
    ...
}

private void UpdateUserRecordLastAccessed2(IDbConnection c, DateTime now)
{
    ... use IDbConnection and now
}

```

### Func<IDbConnection, T>

Any function with a parameter of IDbConnection and a return type of T 

```
public void ExampleSectionOfCode()
{
    ... useful stuff
    db.Execute(GetLastAccessedUserDate, DateTime.Now);
    ...
}

private DateTime GetLastAccessedUserDate(IDbConnection c)
{
    return DateTime using IDbConnection
}

```

### Func<IDbConnection, TIn, TOut>

Any function with a parameter of IDbConnection and another of type TIn a return type of TOut

```
public void ExampleSectionOfCode()
{
    ... useful stuff
    db.Execute(UserRecordGetLastAccessed, userId);
    ...
}

private DateTime UserRecordGetLastAccessed(IDbConnection c, Guid userId)
{
    return DateTime using IDbConnection and userId
}

```

## Transactional

These are the same as the non transactional but you replace IDbConnection with IDbTransaction

```
public void ExampleSectionOfCode()
{
    ... useful stuff
    db.Execute(UserRecordGetLastAccessed, userId);
    ...
}

private DateTime UserRecordGetLastAccessed(IDbTransaction t, Guid userId)
{
    return DateTime using IDbTransaction and userId
}

```

The transaction is commited at the end of execute. If you want to section off different parts of a query just compose them

private void SomethingUseful(IDbTransaction t)
{
    PartA(t);
    PartB(t);
}

private void PartA(IDbTransaction t)
{
    
}

private void PartB(IDbTransaction t)
{
    
}