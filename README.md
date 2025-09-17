# SmartPaper

A repository for providing and sharing information about SmartPaper.

Protect nature, and nature will protect you!</br>
Be free from all bisphenols...

Supports **multiple types of paper** (e.g., order forms, sheets, receipts, number tickets/tags, coupons, tickets) within a single SmartPaper instance, significantly expanding its utility.
Secure transmission and storage are possible through support for AES encryption.

Anyone, including individuals, businesses, public institutions, and governments, can use it freely without any restrictions.

## SmartPaper Data Model

The SmartPaper data model has been significantly updated, effective with version code `202506221515`, to support multiple paper types.

### Data Model Changes

* **New SmartPaper structure**: Now composed of a partial existing SmartPaper structure and a list of `SmartRecord`s. This change enables the management of multiple paper items within a single paper.
* **Renamed**: `SmartPaperItem` to `SmartRecordLine` for better clarity within the new model.

```
SmartPaper (Version Code: 202506221515)
+-------------------------------------------------------------+
| SmartPaper Instance 1                                       |
| +---------------------------------------------------------+ |
| | SmartRecord 1 (of SmartPaper Instance 1)                | |
| | +-----------------------------------------------------+ | |
| | | SmartRecordLine 1 (of SmartRecord 1)                | | |
| | +-----------------------------------------------------+ | |
| | +-----------------------------------------------------+ | |
| | | SmartRecordLine 2 (of SmartRecord 1)                | | |
| | +-----------------------------------------------------+ | |
| | | ...                                                 | | |
| | +-----------------------------------------------------+ | |
| +---------------------------------------------------------+ |
| +---------------------------------------------------------+ |
| | SmartRecord 2 (of SmartPaper Instance 1)                | |
| | +-----------------------------------------------------+ | |
| | | SmartRecordLine 1 (of SmartRecord 2)                | | |
| | +-----------------------------------------------------+ | |
| | | ...                                                 | | |
| | +-----------------------------------------------------+ | |
| +---------------------------------------------------------+ |
| | ...                                                     | |
| +---------------------------------------------------------+ |
+-------------------------------------------------------------+
```

```
SmartPaper (Version Code: 202504101515)
+-------------------------------------------------------------+
| SmartPaper Instance 1                                       |
| +---------------------------------------------------------+ |
| | SmartPaperItem 1 (of SmartPaper Instance 1)             | |
| +---------------------------------------------------------+ |
| | SmartPaperItem 2 (of SmartPaper Instance 1)             | |
| +---------------------------------------------------------+ |
| | ...                                                     | |
| +---------------------------------------------------------+ |
+-------------------------------------------------------------+
```

## Features

This document outlines the key features and configuration options for **SmartPaper**.

---

### Core Functionality

1.  **Paper Size & Layout**:
    * **Width**: Configurable in pixels; automatically adjusts to output screen if larger.
    * **Height**: Dynamically determined by item configuration.
2.  **Borders**: Supports a simple solid-line border around the entire paper. (Other types planned for future support.)
3.  **Security**: Provides support for encrypted paper data and secure URL access.
4.  **Saving**: Offers both manual and automatic saving within a dedicated viewer. You can save multiple SmartRecords 'as one' or 'individually'.
5. **Various SmartRecordLine formats**:
    * **Basic**: Text, Image, Text & Image, Image & Text, Barcode, QR Code
    * **Special**: Padding string (supports multiple texts on a single line)
    * **Interaction**: List, Button, Timer (support coming soon, with real-time data updates)

---

### Supported Content Types & Configuration

SmartPaper supports various content types, each with specific configuration options:

#### Common Configurations

* **Alignment**: Defines positioning within a section.
    * `topLeft (0x11)`, `topCenter (0x110)`, `topRight (0x12)`
    * `centerLeft (0x101)`, `center (0x100)`, `centerRight (0x102)`
    * `bottomLeft (0x21)`, `bottomCenter (0x120)`, `bottomRight (0x22)`
    * `none (0)`

#### Background Image

* **bgImageSrc**: The URL of the background image.
* **bgImageOpacity**: Sets the transparency (opacity) of the background image. It takes a value between 0.0 (fully transparent) and 1.0 (fully opaque).
* **smartPaperImageType**: Defines how the background image will be fitted or repeated within the line's area.
    * BoxFit Series (Image Scaling Methods)
	    * none: Displays the image at its original size. If larger than the area, it will be cropped; if smaller, empty space will appear.
	    * cover: Scales the image while maintaining its aspect ratio to completely cover the area. Parts of the image may be cropped. (Recommended for most background images)
	    * contain: Scales the image while maintaining its aspect ratio so that the entire image is visible within the area. Empty space (letterboxing/pillarboxing) may appear around the image.
	    * fill (stretch): Stretches or shrinks the image to fill the area, disregarding its aspect ratio. The image may appear distorted.
	    * fitWidth: Scales the image while maintaining its aspect ratio to fit the width of the area. The height is adjusted according to the image's aspect ratio.
	    * fitHeight: Scales the image while maintaining its aspect ratio to fit the height of the area. The width is adjusted according to the image's aspect ratio.
	    * scaleDown: If the image is smaller than the area, it behaves like none; if larger, it scales down like contain to fit the area.
    * ImageRepeat Series (Image Repetition Methods)
	    * repeat: Repeats the image horizontally and vertically at its original size until the area is filled.
	    * repeatX: Repeats the image horizontally at its original size until the area is filled.
	    * repeatY: Repeats the image vertically at its original size until the area is filled.

#### Content Types (by `type` property)

1.  **Text (`type = 1`)**
    * **Text Style**:
        * `Font Style`: `normal (0x00000001)`, `italic (0x00000002)`
        * `Font Weight`: `bold (0x00000100)`
        * `Text Decoration`: `underline (0x00010000)`, `overline (0x00020000)`, `lineThrough (0x00040000)`
        * Combinations are also supported (e.g., `normalAndBold`, `italicAndUnderline`).
    * **Properties**: `text`, `fontSize`, `textAlignment`, `textMaxLines`, `textColor`, `textBgColor`

2.  **Image (`type = 0`)**
    * **Properties**: `imageWidth`, `imageHeight`, `imageSrc` (URL)

3.  **Image & Text (`type = 2`)**
    * Image on the left, text on the right.

4.  **Text & Image (`type = 3`)**
    * Text on the left, image on the right.

5.  **Barcode (`type = 5`)**
    * **Properties**: `text` (Barcode data), `imageWidth`, `imageHeight`

6.  **QR Code (`type = 7`)**
    * **Properties**: `text` (QR code data), `imageWidth`, `imageHeight`

7.  **Divider (`type = 4`)**
    * **Style**:
        * `pipe (0) [|]`, `slash (1) [/]`, `backSlash (2) [\\]`, `hyphen (3) [-]`, `sharp (4) [#]`
        * `plus (5) [+]`, `star (6) [*]`, `exclamation (7) [!]`, `at (8) [@]`, `dollar (9) [$]`
        * `percent (10) [%]`, `caret (11) [^]`, `ampersand (12) [&]`, `blank (13) [ ]`
        * `equal (14) [=]`, `underscore (15) [_]`, `dot (16) [.]`, `comma (17) [,]`
        * `custom (99) []`, `none (-1) []`
    * **Property**: `fontSize`

---

### Advanced Text Composition: Pad String (`type = text`)

Used for composing multiple text segments on a single line, often with proportional sizing or padding.

Supports `Alignment Type` (takes precedence) and `Pad Type`.

* **String Delimiters**:
    * `STRING_FORMAT_SEPARATOR ([|SFS|])`
    * `STRING_END_OF ([|SEO|])`

#### Pad String Formats:

1.  **Alignment Type**
    * **Format**: `[text]|SFS|[padFlex]|SFS|[textAlignment]|SEO|`
    * **Properties**:
        * `text`: Content of the text segment.
        * `padFlex`: Proportional integer value for sizing when multiple `Pad String` items are present.
        * `textAlignment`: Alignment value.

2.  **Pad Type**
    * **Format**: `[text]|SFS|[padFlex]|SFS|[padType]|SFS|[padWidth]|SFS|[padText]|SEO|`
    * **Properties**:
        * `text`: Content of the text segment.
        * `padFlex`: Proportional integer value for sizing when multiple `Pad String` items are present.
        * `padType`: `leftPad (0)`, `rightPad (1)`
        * `padWidth`: Width of the padding.
        * `padText`: Character to fill the padding.

## How to use (C# Source code)

```
SmartPaper smartPaper = new();
SmartRecord smartRecord = new();
SmartRecordLine smartRecordLine;
...
smartRecord.items.add(smartRecordLine);
...
smartPaper.smartRecordList.add(smartRecord);
```

* PaperSize

```
public const double defaultPaperWidth = 500; // Default 500
```

* Background Image

```
smartRecord.bgImageSrc = "Background Image URL";
smartRecord.bgImageOpacity = 0.2;
smartRecord.smartPaperImageType = SmartPaperImageType.repeat;
```

* Outline

```
smartRecord.outlineWidth = 2.0;
```

* Type

```
smartRecordLine.type = SmartRecordLineType.image;
```

* Alignment

```
smartRecordLine.textAlignment = SmartRecordLineAlignment.center;
smartRecordLine.imageAlignment = SmartRecordLineAlignment.center;
```

* Text

```
smartRecordLine.textStyle = SmartRecordLineTextStyle.bold;
smartRecordLine.text = "Smart Paper";
smartRecordLine.fontSize = 16.0;
smartRecordLine.textAlignment = SmartRecordLineAlignment.center;
smartRecordLine.textMaxLines = null; // Unlimit
smartRecordLine.textColor = DataManager.IntToColorHex(4278190080); // #FF000000 (#ARGB)
smartRecordLine.textBgColor = DataManager.IntToColorHex(4294967295); // #FFFFFFFF (#ARGB)
```

* Pad String

```
PadString padString;
List<PadString> padStringList = new List<PadString>();
padString = new PadString(text: "Waiting Number ", padFlex: 2, textAlignment: SmartRecordLineAlignment.centerRight);
padStringList.Add(padString);
padString = new PadString(text: "123", padFlex: 1, textAlignment: SmartRecordLineAlignment.centerLeft);
padStringList.Add(padString);
smartRecordLine = SmartPaperHelper.MakePadStringLine(padStringList, textStyle: SmartRecordLineTextStyle.normal, fontSize: 21.0, textColor: "#FFFFFFFF", textBgColor: "#FF000000");
smartRecord.items.Add(smartRecordLine);
```

* Image

```
smartRecordLine = SmartPaperHelper.Image("https://image.example.com/paper.png", imageWidth: 360, imageHeight: 240, SmartRecordLineAlignment.center);
```

* Image & Text

```
smartRecordLine = SmartPaperHelper.ImageAndText("https://image.example.com/paper.png", imageWidth: 360, imageHeight: 240, text: "SmartPaper", textAlignment: SmartRecordLineAlignment.center, fontSize: 16.0, textStyle: SmartRecordLineTextStyle.normal);
```

* Text & Image

```
smartRecordLine = SmartPaperHelper.TextAndImage("https://image.example.com/paper.png", imageWidth: 360, imageHeight: 240, text: "SmartPaper", textAlignment: SmartRecordLineAlignment.center, fontSize: 16.0, textStyle: SmartRecordLineTextStyle.normal);
```

* Divider

```
smartRecordLine = SmartPaperHelper.Divider(dividerStyle: SmartRecordLineDividerStyle.equal, fontSize: 15.0);
smartRecord.items.Add(smartRecordLine);
```

* Barcode

```
smartRecordLine = SmartPaperHelper.Barcode(text: "126af11e3355", imageWidth: paperWidth, imageHeight: 100);
smartRecord.items.Add(smartRecordLine);
```

* QR Code

```
smartRecordLine = SmartPaperHelper.QrCode(text: "126af11e3355", imageWidth: paperWidth, imageHeight: 100);
smartRecord.items.Add(smartRecordLine);
```

* Generate sample JSON

```
SmartPaper smartPaper = Example001.GeneratePaper();
string json = SmartPaper.toJson(smartPaper);
```

* Generate encrypted JSON

```
SmartPaper smartPaper = Example001.GeneratePaper();
string jsonData = SmartPaper.toJson(smartPaper);
string pin = "abc123#@$"; // PIN is the value that the user actually enters.
byte[] keyBytes = SmartPaperManager.GenerateDeterministicKeyFromPin(pin);
byte[] nonceBytes = SmartPaperManager.GenerateUniqueNonce();

string securePayload = SmartPaperManager.EncryptData(jsonData, keyBytes, nonceBytes);	// Encoded in Base64
```

* Generate URL

```
string paperUrl = "https://paper.example.com/order_receipt_001.json";
string? url = SmartPaperManager.GenerateUrl(paperUrl);
```

* Generate Secured URL

```
string paperUrl = "https://paper.example.com/order_receipt_001.paper";
string pin = "abc123#@$"; // PIN is the value that the user actually enters.
byte[] keyBytes = SmartPaperManager.GenerateDeterministicKeyFromPin(pin);
byte[] nonceBytes = SmartPaperManager.GenerateUniqueNonce();

string? surl = SmartPaperManager.EncryptAndGenerateUrl(paperUrl, keyBytes, nonceBytes);
```

## Test Viewer

You can test the smartpaper you created.

<a href="https://www.publicplatform.co.kr/smartpaper/" target="_blank">
  🔗 Open SmartPaper Viewer
</a>

## Samples

* Real-time generation

> Link to [Movie & Parking Ticket](https://app.publicplatform.co.kr/?/smart_paper?type=paper&vendor=theater&savable=true)

> Link to [Waiting Number Ticket](https://app.publicplatform.co.kr/?/smart_paper?type=paper&vendor=bank_waiting_number&savable=true)

* Normal URLs

> Link to [Festival Invitation & Parking Ticket](https://app.publicplatform.co.kr/?/smart_paper?type=url&url=https%3A%2F%2Fsmart-paper.github.io%2FSmartPaper%2Fsamples%2Ffestival_ticket_and_parking_ticket_001.json&autoSave=false)</br><details><summary>View QR Code</summary><img src="https://smart-paper.github.io/SmartPaper/samples/festival_ticket_and_parking_ticket_001.json.png" alt="festival_ticket_and_parking_ticket_001.json" width="200" height="200"></br></details>

> Link to [Order Receipt & Parking Ticket](https://app.publicplatform.co.kr/?/smart_paper?type=url&url=https%3A%2F%2Fsmart-paper.github.io%2FSmartPaper%2Fsamples%2Forder_receipt_and_parking_ticket_001.json&autoSave=false)</br><details><summary>View QR Code</summary><img src="https://smart-paper.github.io/SmartPaper/samples/order_receipt_and_parking_ticket_001.json.png" alt="order_receipt_and_parking_ticket_001.json" width="200" height="200"></br></details>

> Link to [Order Form](https://app.publicplatform.co.kr/?/smart_paper?type=url&url=https%3A%2F%2Fsmart-paper.github.io%2FSmartPaper%2Fsamples%2Forder_form_001.json&autoSave=false)</br><details><summary>View QR Code</summary><img src="https://smart-paper.github.io/SmartPaper/samples/order_form_001.json.png" alt="order_form_001.json" width="200" height="200"></br></details>

> Link to [Order Sheet](https://app.publicplatform.co.kr/?/smart_paper?type=url&url=https%3A%2F%2Fsmart-paper.github.io%2FSmartPaper%2Fsamples%2Forder_sheet_001.json&autoSave=false)</br><details><summary>View QR Code</summary><img src="https://smart-paper.github.io/SmartPaper/samples/order_sheet_001.json.png" alt="order_sheet_001.json" width="200" height="200"></br></details>

> Link to [Order Receipt](https://app.publicplatform.co.kr/?/smart_paper?type=url&url=https%3A%2F%2Fsmart-paper.github.io%2FSmartPaper%2Fsamples%2Forder_receipt_001.json&autoSave=false)</br><details><summary>View QR Code</summary><img src="https://smart-paper.github.io/SmartPaper/samples/order_receipt_001.json.png" alt="order_receipt_001.json" width="200" height="200"></br></details>

> Link to [Number Ticket](https://app.publicplatform.co.kr/?/smart_paper?type=url&url=https%3A%2F%2Fsmart-paper.github.io%2FSmartPaper%2Fsamples%2Fnumber_ticket_001.json&autoSave=false)</br><details><summary>View QR Code</summary><img src="https://smart-paper.github.io/SmartPaper/samples/number_ticket_001.json.png" alt="number_ticket_001.json" width="200" height="200"></br></details>

* Secure URLs (PIN: 1234)

> Link to [Order Receipt & Parking Ticket](https://app.publicplatform.co.kr/?/smart_paper?type=surl&url=%2F3C0KcmfZj69Bsl%2FDBJ29kPlwH68JWEdWujn%2FLEFZdn9i1UokVxJVTlmZusCwprSY21ikMyvjQu5UGqLwdDw7E9m%2F6kZUiOg7fhzrzDQFBuzsr8In%2Fa2sI73OTPTt%2F2eZIIVz4c%2BNtOagUq%2BPSYvOtHO&iv=EBESExQVFhcYGRob&keyBits=256&autoSave=false)</br><details><summary>View QR Code</summary><img src="https://smart-paper.github.io/SmartPaper/samples/secure/order_receipt_and_parking_ticket_001.paper.png" alt="order_receipt_001.paper" width="200" height="200"></br></details>

> Link to [Order Form](https://app.publicplatform.co.kr/?/smart_paper?type=surl&url=%2F3C0KcmfZj69Bsl%2FDBJ29kPlwH68JWEdWujn%2FLEFZdn9i1UokVxJVTlmZusCwprSY21ikMyvjQu5UGqLwdDk5l5uyeldPGy%2B6NdmvE8RrSAXGv6D9vsc6bEuDvQ%3D&iv=EBESExQVFhcYGRob&keyBits=256&autoSave=false)</br><details><summary>View QR Code</summary><img src="https://smart-paper.github.io/SmartPaper/samples/secure/order_form_001.paper.png" alt="order_form_001.paper" width="200" height="200"></br></details>

> Link to [Order Sheet](https://app.publicplatform.co.kr/?/smart_paper?type=surl&url=%2F3C0KcmfZj69Bsl%2FDBJ29kPlwH68JWEdWujn%2FLEFZdn9i1UokVxJVTlmZusCwprSY21ikMyvjQu5UGqLwdDx4Ulm4oZdPXPg%2BcZzqzCzKuamv4IudA0PFVW2JBW%2B&iv=EBESExQVFhcYGRob&keyBits=256&autoSave=false)</br><details><summary>View QR Code</summary><img src="https://smart-paper.github.io/SmartPaper/samples/secure/order_sheet_001.paper.png" alt="order_sheet_001.paper" width="200" height="200"></br></details>

> Link to [Order Receipt](https://app.publicplatform.co.kr/?/smart_paper?type=surl&url=%2F3C0KcmfZj69Bsl%2FDBJ29kPlwH68JWEdWujn%2FLEFZdn9i1UokVxJVTlmZusCwprSY21ikMyvjQu5UGqLwdDw7E9m%2F6kZUnL%2BuIlzrzLeD3sqdYkZeWZK74rFU76DX%2F8%3D&iv=EBESExQVFhcYGRob&keyBits=256&autoSave=false)</br><details><summary>View QR Code</summary><img src="https://smart-paper.github.io/SmartPaper/samples/secure/order_receipt_001.paper.png" alt="order_receipt_001.paper" width="200" height="200"></br></details>

## Language Specific READMEs

* [English](README.md)
* [한국어](README.ko.md)
