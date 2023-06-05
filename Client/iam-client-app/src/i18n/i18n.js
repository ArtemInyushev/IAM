import { createI18n } from 'vue-i18n';
import { supportedLocalesInclude } from './supportedLocales';

function loadLocaleMessages() {
    const locales = require.context(
        "./locales",
        true,
        /[A-Za-z0-9-_,\s]+\.json$/i
    );
    
    const messages = {};
    locales.keys().forEach(key => {
        console.log(key)
        const matched = key.match(/([A-Za-z0-9-_]+)\./i);
        if (matched && matched.length > 1) {
            const locale = matched[1];
            messages[locale] = locales(key);
        }
    });
    return messages;
}

function getStartingLocale() {
    const storageLocale = localStorage.getItem(process.env.VUE_APP_I18N_LOCALE_STORAGE_KEY);
    if (supportedLocalesInclude(storageLocale)) return storageLocale;

    const locale = process.env.VUE_APP_I18N_LOCALE || "ua";
    localStorage.setItem(process.env.VUE_APP_I18N_LOCALE_STORAGE_KEY, locale);
    return locale;
}

const i18n = createI18n({
    warnHtmlInMessage: 'off',
    locale: getStartingLocale(),
    fallbackLocale: process.env.VUE_APP_I18N_FALLBACK_LOCALE,
    messages: loadLocaleMessages()
});

export default i18n;