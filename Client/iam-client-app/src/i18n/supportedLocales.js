import supportedLocales from "./configs/supportedLocalesConfig";

export function getSupportedLocales() {
    let annotatedLocales = [];
    for (const code of Object.keys(supportedLocales)) {
        annotatedLocales.push({
            code,
            name: supportedLocales[code]
        });
    }
}

export function supportedLocalesInclude(locale) {
    return Object.keys(supportedLocales).includes(locale);
}