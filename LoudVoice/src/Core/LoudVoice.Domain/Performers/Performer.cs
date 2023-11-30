using ErrorOr;
using LoudVoice.Domain.Common;
using LoudVoice.Domain.Compositions.ValueObjects;
using LoudVoice.Domain.Performers.Entities;
using LoudVoice.Domain.Performers.Errors;
using LoudVoice.Domain.Performers.ValueObjects;
using LoudVoice.Domain.Users;
using LoudVoice.Domain.Users.ValueObjects;

namespace LoudVoice.Domain.Performers
{
    public sealed class Performer : AggregateRoot<Guid>
    {
        public Nickname Nickname { get; set; }
        public Description Description { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }

        private readonly List<Composition> _compositions = new();
        public IReadOnlyCollection<Composition> Compositions => _compositions;

        private Performer(Guid id) : base(id) { }

        internal Performer(Guid id, Nickname nickname, Description description, Guid userId) 
            : base(id)
        {
            Nickname = nickname;
            Description = description;
            UserId = userId;
        }

        public ErrorOr<Composition> PlaceComposition(CompositionName name, CompositionUrl url)
        {
            var composition = Composition.CreateNew(name, url, this);

            if (Compositions.Any(composition => composition.Url == url && composition.Name == name))
            {
                return CompositionsDomainErrors.CompositionExist;
            }

            _compositions.Add(composition);

            return composition;
        }

        public ErrorOr<bool> RemoveComposition(CompositionId id)
        {
            var composition = _compositions.FirstOrDefault(composition => composition.Id == id);

            if (composition is null)
            {
                return CompositionsDomainErrors.NotFoundComposition;
            }

            _compositions.Remove(composition);

            return true;
        }

        public ErrorOr<bool> UpdateComposition(CompositionId id, CompositionName name, CompositionUrl url)
        {
            var composition = _compositions.FirstOrDefault(composition => composition.Id == id);
            
            if (composition is null)
            {
                return CompositionsDomainErrors.NotFoundComposition;
            }

            composition.Name = name;
            composition.Url = url;

            return true;
        }

        public ErrorOr<Composition> GetCompositionById(CompositionId id)
        {
            var composition = _compositions.FirstOrDefault(compasition => compasition.Id == id);
            
            if(composition is null)
            {
                return CompositionsDomainErrors.NotFoundComposition;
            }

            return composition;
        }

        public ErrorOr<Composition> GetCompositionByName(CompositionName name)
        {
            var composition = _compositions.FirstOrDefault(compasition => compasition.Name == name);

            if (composition is null)
            {
                return CompositionsDomainErrors.NotFoundComposition;
            }

            return composition;
        }
    }
}
