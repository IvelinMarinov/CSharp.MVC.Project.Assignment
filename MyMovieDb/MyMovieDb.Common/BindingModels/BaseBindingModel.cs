namespace MyMovieDb.Common.BindingModels
{
    public abstract class BaseBindingModel
    {
        public int? Id { get; set; }

        public bool HasError { get; set; }

        public string Message { get; set; }

        public void SetError(string message)
        {
            this.HasError = true;
            this.Message = message;
        }
    }
}
