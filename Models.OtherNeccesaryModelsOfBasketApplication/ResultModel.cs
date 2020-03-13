namespace Models.OtherNeccesaryModelsOfBasketApplication
{
    public sealed class ResultModel
    {
        #region Constructors
        private ResultModel() { }
        #endregion Constructors

        #region Global Parameters
        public string ResultMessage { get; private set; }
        public bool IsResultSuccessful { get; private set; }
        #endregion Global Parameters

        #region Private Function(s)
        private static ResultModel CreateResultModel(string resultMessage, bool isResultSuccessful = default(bool)) => new ResultModel
        {
            ResultMessage = resultMessage,
            IsResultSuccessful = isResultSuccessful
        };
        #endregion Private Function(s)

        #region Public Functions
        /// <summary>
        /// Basarili islemler icin kullanilacak olan ResultModel
        /// </summary>
        /// <param name="messageOfResultSuccessful">Basarili islem mesaji</param>
        /// <returns></returns>
        public static ResultModel SuccessfulResult(string messageOfResultSuccessful = "") => CreateResultModel(isResultSuccessful: true,
                                                                                                               resultMessage: messageOfResultSuccessful);
        /// <summary>
        /// Basarisiz islemler icin kullanilacak olan ResultModel
        /// </summary>
        /// <param name="messageOfResultUnsuccessful">Basarisiz islem mesaji</param>
        /// <returns></returns>
        public static ResultModel UnsuccessfulResult(string messageOfResultUnsuccessful = "") => CreateResultModel(isResultSuccessful: default(bool),
                                                                                                                   resultMessage: messageOfResultUnsuccessful);
        #endregion Public Functions
    }
}
