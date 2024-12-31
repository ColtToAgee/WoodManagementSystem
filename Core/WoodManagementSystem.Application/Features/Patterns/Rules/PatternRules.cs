using WoodManagementSystem.Application.Bases;
using WoodManagementSystem.Application.Features.Patterns.Exceptions;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Patterns.Rules
{
    public class PatternRules : BaseRules
    {
        public Task PatternNameMustNotBeSame(IList<Pattern> patterns, string patternName)
        {
            if (patterns.Any(a => a.PatternName == patternName)) throw new PatternNameMustNotBeSameException();
            return Task.CompletedTask;
        }

        public Task PatternIsNotFound(Pattern pattern)
        {
            if (pattern is null) throw new PatternIsNotFoundException();
            return Task.CompletedTask;
        }
    }
}
