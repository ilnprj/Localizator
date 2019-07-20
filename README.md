## Localizator
**Simple Localizator** for Unity3D (works with XML, JSON files)

#### Features
- **Localizator.cs**
  - Main static class.
- **GetLocalizeText.cs**
  - A component that is bound to UI.Text and that sets localized text by key.
- **IParseableLocalize.cs**
  - All parsers of any type must implement this interface. The interface is set to Localizator.
- **XMLParse.cs**
  - Parser that takes localization keys from an xml file and returns them to Localizator class.


