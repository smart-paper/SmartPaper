# Smart Paper

A repository for providing and sharing information about smart paper.

Be free from all bisphenols!</br>
Protect nature, and nature will protect you!

Supports various types of paper, including order forms, receipts, number tickets(number tags), coupons, and tickets.

## Features

* Alignment
> Top: topLeft(0x11), topCenter(0x110), topRight(0x12)</br>
> Center: centerLeft(0x101), center(0x100), centerRight(0x102)</br>
> Bottom: bottomLeft(0x21), bottomCenter(0x120), bottomRight(0x22)</br>
> Not Set: none(0)

* Outline
> Outline Type: Among solid line, dotted line, dashed line, thick line, thin line, and double line, only solid line is currently supported</br>
> outlineWidth: Real number greater than 0

* Text: type = text
> textStyle:</br>
> Font Style: normal(0x00000001), italic(0x00000002)</br>
> Font Weight: bold(0x00000100)</br>
> Text Decoration: underline(0x00010000), overline(0x00020000), lineThrough(0x00040000)</br>
> Font Style & Font Weight: normalAndBold(0x00000101), italicAndBold(0x00000102)</br>
> Font Style & Text Decoration: normalAndUnderline(0x00010001), normalAndOverline(0x00020001), normalAndLineThrough(0x00040001),italicAndUnderline(0x00010002), italicAndOverline(0x00020002), italicAndLineThrough(0x00040002)</br>
> FontStyle & Font Weight & Text Decoration: normalAndBoldAndUnderline(0x00010101), normalAndBoldAndOverline(0x00020101), normalAndBoldAndLineThrough(0x00040101), italicAndBoldAndUnderline(0x00010102), italicAndBoldAndOverline(0x00020102), italicAndBoldAndLineThrough(0x00040102)</br>
> text: Text</br>
> textSize: Font Size

* Pad String: type = text
> Item for composing text with pad</br>
> Multiple items can be used to output multiple texts on one line</br>
> Supports 'Alignment Type' and 'Pad Type', with 'Alignment Type' taking precedence</br></br>
> String Divider: STRING_FORMAT_SEPARATOR([|SFS|]), STRING_END_OF([|SEO|])</br></br>
> **Alignment Type**</br>
> [text]STRING_FORMAT_SEPARATOR[padFlex]STRING_FORMAT_SEPARATOR[alignment]STRING_END_OF</br>
> text: Text</br>
> padFlex: When composed of multiple 'Pad String', a proportional integer value for the size of another 'Pad String'</br>
> alignment: Alignment value</br></br>
> **Pad Type**</br>
> [text]STRING_FORMAT_SEPARATOR[padFlex]STRING_FORMAT_SEPARATOR[padType]STRING_FORMAT_SEPARATOR[padWidth]STRING_FORMAT_SEPARATOR[padText]STRING_END_OF</br>
> text: Text</br>
> padFlex: When composed of multiple 'Pad String', a proportional integer value for the size of another 'Pad String'</br>
> padType: leftPad(0), rightPad(1)</br>
> padWidth: Pad Width</br>
> padText: Text to be filled with pad

* Image: type = image</br>
> imageWidth: Image Width</br>
> imageHeight: Image Height</br>
> imageSrc: Image Source (URL)

* Image & Text: type = imageAndText
> Image on the left, text on the right

* Text & Image: type = textAndImage
> Text on the left, image on the right

* Divider : type = divider
> Divider Style: pipe(0)[|], slash(1)[/], backSlash(2)[\], hyphen(3)[-], sharp(4)[#], plus(5)[+], star(6)[*],
  exclamation(7)[!], at(8)[@], dollar(9)[$], percent(10)[%], caret(11)[^], ampersand(12)[&], blank(13)[ ], equal(14)[=], underscore(15)[_], dot(16)[.], comma(17)[,], custom(99)[], none(-1)[];

* Barcode: type = barcode
> text: Barcode Text</br>
> imageWidth: Image Width</br>
> imageHeight: Image Height

* QR Code: type = qrcode
> text: QR code text</br>
> imageWidth: Image Width</br>
> imageHeight: Image Height

## Samples

* Normal URLs

> Link to [Order Sheet](https://app.publicplatform.co.kr/?/smart_paper?type=url&url=https%3A%2F%2Fsmart-paper.github.io%2FSmartPaper%2Fsamples%2Forder_sheet_001.json)</br><details><summary>View QR Code</summary><img src="https://smart-paper.github.io/SmartPaper/samples/order_sheet_001.json.png" alt="order_sheet_001.json" width="200" height="200"></br></details>

> Link to [Order Receipt](https://app.publicplatform.co.kr/?/smart_paper?type=url&url=https%3A%2F%2Fsmart-paper.github.io%2FSmartPaper%2Fsamples%2Forder_receipt_001.json)</br><details><summary>View QR Code</summary><img src="https://smart-paper.github.io/SmartPaper/samples/order_receipt_001.json.png" alt="order_receipt_001.json" width="200" height="200"></br></details>

> Link to [Number Ticket](https://app.publicplatform.co.kr/?/smart_paper?type=url&url=https%3A%2F%2Fsmart-paper.github.io%2FSmartPaper%2Fsamples%2Fnumber_ticket_001.json)</br><details><summary>View QR Code</summary><img src="https://smart-paper.github.io/SmartPaper/samples/number_ticket_001.json.png" alt="number_ticket_001.json" width="200" height="200"></br></details>

* Secure URLs (Password: 1234)

> Link to [Order Sheet](https://app.publicplatform.co.kr/?/smart_paper?type=surl&url=AQV%2Bw0n5tUDhm%2BWEyX26PJNRA2QVb%2Fw3wq24e7QsYecWoevx3MfeqtW%2FLmIv64R6tEc1jYZu2ZoYl%2BtL6JowXaOfGhfM7endutkOseiRSXg%3D&iv=EBESExQVFhcYGRobHB0eHw%3D%3D&keyBits=256)</br><details><summary>View QR Code</summary><img src="https://smart-paper.github.io/SmartPaper/samples/secure/order_sheet_001.paper.png" alt="order_sheet_001.paper" width="200" height="200"></br></details>

> Link to [Order Receipt](https://app.publicplatform.co.kr/?/smart_paper?type=surl&url=AQV%2Bw0n5tUDhm%2BWEyX26PJNRA2QVb%2Fw3wq24e7QsYecWoevx3MfeqtW%2FLmIv64R6tEc1jYZu2ZoYl%2BtL6JoxUKWfBziIgujD%2B5YOter3OHo%3D&iv=EBESExQVFhcYGRobHB0eHw%3D%3D&keyBits=256)</br><details><summary>View QR Code</summary><img src="https://smart-paper.github.io/SmartPaper/samples/secure/order_receipt_001.paper.png" alt="order_receipt_001.paper" width="200" height="200"></br></details>

## Language Specific READMEs

* [English](README.md)
* [한국어](README.ko.md)