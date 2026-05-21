

namespace Alis.Extension.Language.Translator.Abstractions
{
    /// <summary>
    ///     Interface that defines the contract for observing translation events
    /// </summary>
    /// <remarks>
    ///     Observers are notified when important translation events occur,
    ///     such as language changes or translation updates.
    /// </remarks>
    public interface ITranslationObserver
    {
        /// <summary>
        ///     Called when the current language has changed
        /// </summary>
        /// <param name="language">The newly selected language</param>
        void OnLanguageChanged(ILanguage language);

        /// <summary>
        ///     Called when translations have been updated
        /// </summary>
        /// <param name="languageCode">The language code that was updated</param>
        void OnTranslationsUpdated(string languageCode);

        /// <summary>
        ///     Called when a translation is requested but not found
        /// </summary>
        /// <param name="languageCode">The language code</param>
        /// <param name="key">The translation key that was not found</param>
        void OnTranslationNotFound(string languageCode, string key);
    }
}