﻿namespace Training.Application.Attributes;

/// <summary>
///     Usado por los request para indicar el validador usado por el request.
/// </summary>
/// <typeparam name="TValidator">
///     Tipo del validador usado por el Request.
/// </typeparam>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ValidatorAttribute<TValidator> : Attribute where TValidator : FluentValidation.IValidator
{
    /// <summary>
    ///     Tipo del validador usado por el request.
    /// </summary>
    public readonly Type ValidatorType = typeof(TValidator);
}