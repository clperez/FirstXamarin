using System;

namespace Qwantalabs.Shared
{
    public static class Functional
    {
        public static TInput If<TInput>(this TInput input, Func<TInput, bool> evaluator) =>
            Object.Equals(input, default(TInput)) || !evaluator(input) ? default : input;

        // Project a type into another
        public static TResult Select<TInput, TResult>(this TInput input, Func<TInput, TResult> evaluator, TResult failureValue) =>
            Object.Equals(input, default(TInput)) ? failureValue : evaluator(input);

        // Project a type into another
        public static TResult Select<TInput, TResult>(this TInput input, Func<TInput, TResult> evaluator) =>
            input.Select(evaluator, default);

        // This one can be concatenated. Many Do Do Do Do
        public static TInput Do<TInput>(this TInput input, Action<TInput> action){
            if (Object.Equals(input, default(TInput))) return default;
            action(input);
            return input;
        }

    }
}
