namespace Entity.BaseEntities
{
    /// <summary>
    /// Base service output dto
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseOutputDto<T>
    {
        public T Result { get; set; }

        public IEnumerable<Error> ErrorList { get; set; } = new List<Error>();
    }
}
