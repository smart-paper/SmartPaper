# SmartPaper

A repository for providing and sharing information about SmartPaper.

Protect nature, and nature will protect you!</br>
Be free from all bisphenols...

Supports various types of paper, including order forms, sheets, receipts, number tickets(number tags), coupons, and tickets.</br>
Secure transmission and storage is possible through support for AES encryption (default 256-bit).

## Features

* Paper Size
> paperWidth: Paper Width
> The paper height is determined by the Item configuration.

* Outline
> Outline Type: Among solid line, dotted line, dashed line, thick line, thin line, and double line, only solid line is currently supported</br>
> outlineWidth: Real number greater than 0

* Type
> image(0), text(1), imageAndText(2), textAndImage(3), divider(4), barcode(5), qrcode(6)

* Alignment
> Top: topLeft(0x11), topCenter(0x110), topRight(0x12)</br>
> Center: centerLeft(0x101), center(0x100), centerRight(0x102)</br>
> Bottom: bottomLeft(0x21), bottomCenter(0x120), bottomRight(0x22)</br>
> Not Set: none(0)

* Text: type = text
> textStyle:</br>
> Font Style: normal(0x00000001), italic(0x00000002)</br>
> Font Weight: bold(0x00000100)</br>
> Text Decoration: underline(0x00010000), overline(0x00020000), lineThrough(0x00040000)</br>
> Font Style & Font Weight: normalAndBold(0x00000101), italicAndBold(0x00000102)</br>
> Font Style & Text Decoration: normalAndUnderline(0x00010001), normalAndOverline(0x00020001), normalAndLineThrough(0x00040001),italicAndUnderline(0x00010002), italicAndOverline(0x00020002), italicAndLineThrough(0x00040002)</br>
> FontStyle & Font Weight & Text Decoration: normalAndBoldAndUnderline(0x00010101), normalAndBoldAndOverline(0x00020101), normalAndBoldAndLineThrough(0x00040101), italicAndBoldAndUnderline(0x00010102), italicAndBoldAndOverline(0x00020102), italicAndBoldAndLineThrough(0x00040102)</br>
> **[text]**</br>
> Text</br>
> **[fontSize]**</br>
> Font Size</br>
> **[textAlignment]**</br>
> Alignment value</br>
> **[textMaxLines]**</br>
> Text Maximum Lines</br>
> **[textColor]**</br>
> Text Color</br>
> **[textBgColor]**</br>
> Text Background Color 

* Pad String: type = text
> Item for composing text with pad</br>
> Multiple items can be used to output multiple texts on one line</br>
> Supports 'Alignment Type' and 'Pad Type', with 'Alignment Type' taking precedence</br></br>
> String Divider: STRING_FORMAT_SEPARATOR([|SFS|]), STRING_END_OF([|SEO|])</br></br>
> **Alignment Type**</br>
> [text]STRING_FORMAT_SEPARATOR[padFlex]STRING_FORMAT_SEPARATOR[textAlignment]STRING_END_OF</br>
> **[text]**</br>
> Text</br>
> **[padFlex]**</br>
> When composed of multiple 'Pad String', a proportional integer value for the size of another 'Pad String'</br>
> **[textAlignment]**</br>
> Alignment value</br></br>
> **Pad Type**</br>
> [text]STRING_FORMAT_SEPARATOR[padFlex]STRING_FORMAT_SEPARATOR[padType]STRING_FORMAT_SEPARATOR[padWidth]STRING_FORMAT_SEPARATOR[padText]STRING_END_OF</br>
> **[text]**</br>
> Text</br>
> **[padFlex]**</br>
> When composed of multiple 'Pad String', a proportional integer value for the size of another 'Pad String'</br>
> **[padType]**</br>
> leftPad(0), rightPad(1)</br>
> **[padWidth]**</br>
> Pad Width</br>
> **[padText]**</br>
> Text to be filled with pad

* Image: type = image</br>
> **[imageWidth]**</br>
> Image Width</br>
> **[imageHeight]**</br>
> Image Height</br>
> **[imageSrc]**</br>
> Image Source (URL)

* Image & Text: type = imageAndText
> Image on the left, text on the right

* Text & Image: type = textAndImage
> Text on the left, image on the right

* Divider : type = divider
> Divider Style: pipe(0)[|], slash(1)[/], backSlash(2)[\\], hyphen(3)[-], sharp(4)[#], plus(5)[+], star(6)[*],
  exclamation(7)[!], at(8)[@], dollar(9)[$], percent(10)[%], caret(11)[^], ampersand(12)[&], blank(13)[ ], equal(14)[=], underscore(15)[_], dot(16)[.], comma(17)[,], custom(99)[], none(-1)[];
> **[fontSize]**</br>
> Font Size

* Barcode: type = barcode
> **[text]**</br>
> Barcode Text</br>
> **[imageWidth]**</br>
> Image Width</br>
> **[imageHeight]**</br>
> Image Height

* QR Code: type = qrcode
> **[text]**</br>
> QR code text</br>
> **[imageWidth]**</br>
> Image Width</br>
> **[imageHeight]**</br>
> Image Height

## How to use (C# Source code)

```
SmartPaper smartPaper;
SmartPaperItem smartPaperItem;
```

* PaperSize

```
paper.paperWidth = 500; // Default 500
```

* Outline

```
paper.outlineWidth = 2.0;
```

* Type

```
smartPaperItem.type = SmartPaperItemType.image;
```

* Alignment

```
smartPaperItem.textAlignment = SmartPaperItemAlignment.center;
smartPaperItem.imageAlignment = SmartPaperItemAlignment.center;
```

* Text

```
smartPaperItem.textStyle = SmartPaperItemTextStyle.bold;
smartPaperItem.text = "Smart Paper";
smartPaperItem.fontSize = 16.0;
smartPaperItem.textAlignment = SmartPaperItemAlignment.center;
smartPaperItem.textMaxLines = null; // Unlimit
smartPaperItem.textColor = DataManager.IntToColorHex(4278190080); // #FF000000 (#ARGB)
smartPaperItem.textBgColor = DataManager.IntToColorHex(4294967295); // #FFFFFFFF (#ARGB)
```

* Pad String

```
PadString padString;
List<PadString> padStringList = new List<PadString>();
padString = new PadString(text: "Waiting Number ", padFlex: 2, textAlignment: SmartPaperItemAlignment.centerRight);
padStringList.Add(padString);
padString = new PadString(text: "123", padFlex: 1, textAlignment: SmartPaperItemAlignment.centerLeft);
padStringList.Add(padString);
smartPaperItem = SmartPaperHelper.MakePadStringItem(padStringList, textStyle: SmartPaperItemTextStyle.normal, fontSize: 21.0, textColor: "#FFFFFFFF", textBgColor: "#FF000000");
smartPaper.items.Add(smartPaperItem);
```

* Image

```
smartPaperItem = SmartPaperHelper.Image("https://image.example.com/paper.png", imageWidth: 360, imageHeight: 240, SmartPaperItemAlignment.center);
```

* Image & Text

```
smartPaperItem = SmartPaperHelper.ImageAndText("https://image.example.com/paper.png", imageWidth: 360, imageHeight: 240, text: "SmartPaper", textAlignment: SmartPaperItemAlignment.center, fontSize: 16.0, textStyle: SmartPaperItemTextStyle.normal);
```

* Text & Image

```
smartPaperItem = SmartPaperHelper.TextAndImage("https://image.example.com/paper.png", imageWidth: 360, imageHeight: 240, text: "SmartPaper", textAlignment: SmartPaperItemAlignment.center, fontSize: 16.0, textStyle: SmartPaperItemTextStyle.normal);
```

* Divider

```
smartPaperItem = SmartPaperHelper.Divider(dividerStyle: SmartPaperItemDividerStyle.equal, fontSize: 15.0);
smartPaper.items.Add(smartPaperItem);
```

* Barcode

```
smartPaperItem = SmartPaperHelper.Barcode(text: "126af11e3355", imageWidth: paperWidth, imageHeight: 100);
smartPaper.items.Add(smartPaperItem);
```

* QR Code

```
smartPaperItem = SmartPaperHelper.QrCode(text: "126af11e3355", imageWidth: paperWidth, imageHeight: 100);
smartPaper.items.Add(smartPaperItem);
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
byte[] keyBytes = SecurityManager.GenerateDeterministicKeyFromPin(pin);
byte[] ivBytes = SecurityManager.GenerateUniqueIV();

string securePayload = SecurityManager.EncryptJsonData(jsonData, keyBytes, ivBytes);	// Encoded in Base64
```

* Generate URL

```
string paperUrl = "https://paper.example.com/order_receipt_001.json";
string? url = SecurityManager.GenerateUrl(paperUrl);
```

* Generate Secured URL

```
string paperUrl = "https://paper.example.com/order_receipt_001.paper";
string pin = "abc123#@$"; // PIN is the value that the user actually enters.
byte[] keyBytes = SecurityManager.GenerateDeterministicKeyFromPin(pin);
byte[] ivBytes = SecurityManager.GenerateUniqueIV();

string? surl = SecurityManager.EncryptAndGenerateUrl(paperUrl, keyBytes, ivBytes);
```

## Test Viewer

You can test the smartpaper you created.

<a href="https://www.publicplatform.co.kr/smartpaper/" target="_blank">
  🔗 Open SmartPaper Viewer
</a>

## Samples

* Normal URLs

> Link to [Order Form](https://app.publicplatform.co.kr/?/smart_paper?type=url&url=https%3A%2F%2Fsmart-paper.github.io%2FSmartPaper%2Fsamples%2Forder_form_001.json)</br><details><summary>QR 코드 보기</summary><img src="https://smart-paper.github.io/SmartPaper/samples/order_form_001.json.png" alt="order_form_001.json" width="200" height="200"></br></details>

> Link to [Order Sheet](https://app.publicplatform.co.kr/?/smart_paper?type=url&url=https%3A%2F%2Fsmart-paper.github.io%2FSmartPaper%2Fsamples%2Forder_sheet_001.json)</br><details><summary>View QR Code</summary><img src="https://smart-paper.github.io/SmartPaper/samples/order_sheet_001.json.png" alt="order_sheet_001.json" width="200" height="200"></br></details>

> Link to [Order Receipt](https://app.publicplatform.co.kr/?/smart_paper?type=url&url=https%3A%2F%2Fsmart-paper.github.io%2FSmartPaper%2Fsamples%2Forder_receipt_001.json)</br><details><summary>View QR Code</summary><img src="https://smart-paper.github.io/SmartPaper/samples/order_receipt_001.json.png" alt="order_receipt_001.json" width="200" height="200"></br></details>

> Link to [Number Ticket](https://app.publicplatform.co.kr/?/smart_paper?type=url&url=https%3A%2F%2Fsmart-paper.github.io%2FSmartPaper%2Fsamples%2Fnumber_ticket_001.json)</br><details><summary>View QR Code</summary><img src="https://smart-paper.github.io/SmartPaper/samples/number_ticket_001.json.png" alt="number_ticket_001.json" width="200" height="200"></br></details>

* Secure URLs (PIN: 1234)

> Link to [Order Form](https://app.publicplatform.co.kr/?/smart_paper?type=surl&url=AQV%2Bw0n5tUDhm%2BWEyX26PJNRA2QVb%2Fw3wq24e7QsYecWoevx3MfeqtW%2FLmIv64R6tEc1jYZu2ZoYl%2BtL6JolWrSXMXjM7PaDq8gbpp6WTn8%3D&iv=EBESExQVFhcYGRobHB0eHw%3D%3D&keyBits=256)</br><details><summary>QR 코드 보기</summary><img src="https://smart-paper.github.io/SmartPaper/samples/secure/order_form_001.paper.png" alt="order_form_001.paper" width="200" height="200"></br></details>

> Link to [Order Sheet](https://app.publicplatform.co.kr/?/smart_paper?type=surl&url=AQV%2Bw0n5tUDhm%2BWEyX26PJNRA2QVb%2Fw3wq24e7QsYecWoevx3MfeqtW%2FLmIv64R6tEc1jYZu2ZoYl%2BtL6JowXaOfGhfM7endutkOseiRSXg%3D&iv=EBESExQVFhcYGRobHB0eHw%3D%3D&keyBits=256)</br><details><summary>View QR Code</summary><img src="https://smart-paper.github.io/SmartPaper/samples/secure/order_sheet_001.paper.png" alt="order_sheet_001.paper" width="200" height="200"></br></details>

> Link to [Order Receipt](https://app.publicplatform.co.kr/?/smart_paper?type=surl&url=AQV%2Bw0n5tUDhm%2BWEyX26PJNRA2QVb%2Fw3wq24e7QsYecWoevx3MfeqtW%2FLmIv64R6tEc1jYZu2ZoYl%2BtL6JoxUKWfBziIgujD%2B5YOter3OHo%3D&iv=EBESExQVFhcYGRobHB0eHw%3D%3D&keyBits=256)</br><details><summary>View QR Code</summary><img src="https://smart-paper.github.io/SmartPaper/samples/secure/order_receipt_001.paper.png" alt="order_receipt_001.paper" width="200" height="200"></br></details>

## Language Specific READMEs

* [English](README.md)
* [한국어](README.ko.md)
