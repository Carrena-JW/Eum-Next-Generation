namespace Eum.Shared.Common.Bases
{
	public abstract class EntityBase<T>
	{
		public abstract T Create(T input);
		public abstract T Delete(int id);
		public abstract T Update(int id);
		public abstract T Read(int id);

	}
}

