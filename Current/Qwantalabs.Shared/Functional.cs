using System;
using System.Threading.Tasks;

namespace Qwantalabs.Shared
{
    public static class Functional
    {
        public static TInput If<TInput>(this TInput input, Func<TInput, bool> evaluator) {
            if (Object.Equals(input, default(TInput))) return default;
            return evaluator(input) ? input : default;
        }
        
        // Project a type into another
        public static TResult Select<TInput, TResult>(this TInput input, Func<TInput, TResult> evaluator, TResult failureValue)
        {
            if (Object.Equals(input, default(TInput))) return failureValue;
            return evaluator(input);
        }
        
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


    public static class FunctionalAsync
    {
        // Project a type into another
        public static async Task<TResult> SelectAsync<TInput, TResult>(this TInput input, Func<TInput, TResult> evaluator, ValueTask<TResult> failureValue) =>
            Object.Equals(input, default(TInput)) ? await failureValue : evaluator(input);

        // Project a type into another
        public static async Task<TResult> SelectAsync<TInput, TResult>(this TInput input, Func<TInput, TResult> evaluator) =>
            await input.SelectAsync(evaluator, default);

        // This one can be concatenated. Many Do Do Do Do
        public static async Task<TInput> DoAsync<TInput>(this TInput input, Func<TInput,Task> action)
        {
            if (Object.Equals(input, default(TInput))) return default;
            await action(input);
            return input;
        }
    }
}
