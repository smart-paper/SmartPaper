# SmartPaper

스마트페이퍼에 대한 정보를 제공하고 공유하는 저장소입니다.

자연을 보호해야 자연도 여러분들을 보호합니다!</br>
모든 비스페놀로부터 자유로워지세요...

주문서, 영수증, 번호표/번호태그, 쿠폰, 티켓 등 다양한 종류의 용지를 지원합니다.
AES 암호화(기본 256 비트) 지원을 통해 안전한 전송 및 저장이 가능합니다.

## Features

* 정렬 (Alignment)
> 상단: topLeft(0x11), topCenter(0x110), topRight(0x12)</br>
> 중앙: centerLeft(0x101), center(0x100), centerRight(0x102)</br>
> 하단: bottomLeft(0x21), bottomCenter(0x120), bottomRight(0x22)</br>
> 설정 안함: none(0)

* 테두리 (Outline)
> 테두리 타입: 실선, 점선, 파선, 굵은 선, 가는 선, 이중 선 중에서 현재는 실선만 지원</br>
> outlineWidth: 0보다 큰 실수

* 텍스트 (Text): type = text
> **[textStyle]**</br>
> 폰트 스타일 (Font Style): normal(0x00000001), italic(0x00000002)</br>
> 폰트 두께 (Font Weight): bold(0x00000100)</br>
> 텍스트 장식 (Text Decoration): underline(0x00010000), overline(0x00020000), lineThrough(0x00040000)</br>
> 폰트 스타일 & 폰트 두께: normalAndBold(0x00000101), italicAndBold(0x00000102)</br>
> 폰트 스타일 & 텍스트 장식: normalAndUnderline(0x00010001), normalAndOverline(0x00020001), normalAndLineThrough(0x00040001),italicAndUnderline(0x00010002), italicAndOverline(0x00020002), italicAndLineThrough(0x00040002)</br>
> 폰트 스타일 & 폰트 두께 & 텍스트 장식: normalAndBoldAndUnderline(0x00010101), normalAndBoldAndOverline(0x00020101), normalAndBoldAndLineThrough(0x00040101), italicAndBoldAndUnderline(0x00010102), italicAndBoldAndOverline(0x00020102), italicAndBoldAndLineThrough(0x00040102)</br>
> **[text]**</br>
> 텍스트</br>
> **[fontSize]**</br>
> 폰트 크기

* 패드 문자열 (Pad String): type = text
> 패드를 가진 텍스트를 구성하기 위한 아이템</br>
> 여러 개의 아이템으로 구성하면 한 줄에 여러 개의 텍스트 출력 가능</br>
> '정렬 타입'과 '패드 타입'을 지원하며 '정렬 타입'이 우선 됨</br></br>
> String Divider: STRING_FORMAT_SEPARATOR([|SFS|]), STRING_END_OF([|SEO|])</br></br>
> **정렬 타입 (Alignment Type)**</br>
> [text]STRING_FORMAT_SEPARATOR[padFlex]STRING_FORMAT_SEPARATOR[alignment]STRING_END_OF</br>
> **[text]**</br>
> 텍스트</br>
> **[padFlex]**</br>
> 여러 개의 'Pad String'으로 구성될 때 다른 'Pad String'의 크기에 대한 비례되는 정수 값</br>
> **[alignment]**</br>
> 정렬 값</br></br>
> **패드 타입 (Pad Type)**</br>
> [text]STRING_FORMAT_SEPARATOR[padFlex]STRING_FORMAT_SEPARATOR[padType]STRING_FORMAT_SEPARATOR[padWidth]STRING_FORMAT_SEPARATOR[padText]STRING_END_OF</br>
> **[text]**</br>
> 텍스트</br>
> **[padFlex]**</br>
> 여러 개의 'Pad String'으로 구성될 때 다른 'Pad String'의 크기에 대한 비례되는 정수 값</br>
> **[padType]**</br>
> leftPad(0), rightPad(1)</br>
> **[padWidth]**</br>
> 패드 너비</br>
> **[padText]**</br>
> 패드로 채울 텍스트

* 이미지 (Image): type = image</br>
> **[imageWidth]**</br>
> 이미지 너비</br>
> **[imageHeight]**</br>
> 이미지 높이</br>
> **[imageSrc]**</br>
> 이미지 소스 (URL)

* 이미지 & 텍스트 (Image & Text): type = imageAndText
> 왼쪽에 이미지, 오른쪽에 텍스트

* 텍스트 & 이미지 (Text & Image): type = textAndImage
> 왼쪽에 텍스트, 오른쪽에 이미지

* 구분선 (Divider) : type = divider
> Divider Style: pipe(0)[|], slash(1)[/], backSlash(2)[\\], hyphen(3)[-], sharp(4)[#], plus(5)[+], star(6)[*],
  exclamation(7)[!], at(8)[@], dollar(9)[$], percent(10)[%], caret(11)[^], ampersand(12)[&], blank(13)[ ], equal(14)[=], underscore(15)[_], dot(16)[.], comma(17)[,], custom(99)[], none(-1)[];
> **[fontSize]**</br>
> 폰트 크기

* 바코드 (Barcode): type = barcode
> **[text]**</br>
> 바코드 텍스트</br>
> **[imageWidth]**</br>
> 이미지 너비</br>
> **[imageHeight]**</br>
> 이미지 높이

* QR 코드 (QR Code): type = qrcode
> **[text]**</br>
> QR 코드 텍스트</br>
> **[imageWidth]**</br>
> 이미지 너비</br>
> **[imageHeight]**</br>
> 이미지 높이

## Viewer for Testing

생성한 스마트페이퍼를 테스트할 수 있습니다.

<a href="https://smart-paper.github.io/SmartPaper/" target="_blank">
  🔗 스마트페이퍼 뷰어 열기 (새 창)
</a>

## Samples

* 일반 URLs

> [주문서](https://app.publicplatform.co.kr/?/smart_paper?type=url&url=https%3A%2F%2Fsmart-paper.github.io%2FSmartPaper%2Fsamples%2Forder_sheet_001.json) 링크</br><details><summary>QR 코드 보기</summary><img src="https://smart-paper.github.io/SmartPaper/samples/order_sheet_001.json.png" alt="order_sheet_001.json" width="200" height="200"></br></details>

> [영수증](https://app.publicplatform.co.kr/?/smart_paper?type=url&url=https%3A%2F%2Fsmart-paper.github.io%2FSmartPaper%2Fsamples%2Forder_receipt_001.json) 링크</br><details><summary>QR 코드 보기</summary><img src="https://smart-paper.github.io/SmartPaper/samples/order_receipt_001.json.png" alt="order_receipt_001.json" width="200" height="200"></br></details>

> [번호표](https://app.publicplatform.co.kr/?/smart_paper?type=url&url=https%3A%2F%2Fsmart-paper.github.io%2FSmartPaper%2Fsamples%2Fnumber_ticket_001.json) 링크</br><details><summary>QR 코드 보기</summary><img src="https://smart-paper.github.io/SmartPaper/samples/number_ticket_001.json.png" alt="number_ticket_001.json" width="200" height="200"></br></details>

* 보안 URLs (비빌번호: 1234)

> [주문서](https://app.publicplatform.co.kr/?/smart_paper?type=surl&url=AQV%2Bw0n5tUDhm%2BWEyX26PJNRA2QVb%2Fw3wq24e7QsYecWoevx3MfeqtW%2FLmIv64R6tEc1jYZu2ZoYl%2BtL6JowXaOfGhfM7endutkOseiRSXg%3D&iv=EBESExQVFhcYGRobHB0eHw%3D%3D&keyBits=256) 링크</br><details><summary>QR 코드 보기</summary><img src="https://smart-paper.github.io/SmartPaper/samples/secure/order_sheet_001.paper.png" alt="order_sheet_001.paper" width="200" height="200"></br></details>

> [영수증](https://app.publicplatform.co.kr/?/smart_paper?type=surl&url=AQV%2Bw0n5tUDhm%2BWEyX26PJNRA2QVb%2Fw3wq24e7QsYecWoevx3MfeqtW%2FLmIv64R6tEc1jYZu2ZoYl%2BtL6JoxUKWfBziIgujD%2B5YOter3OHo%3D&iv=EBESExQVFhcYGRobHB0eHw%3D%3D&keyBits=256) 링크</br><details><summary>QR 코드 보기</summary><img src="https://smart-paper.github.io/SmartPaper/samples/secure/order_receipt_001.paper.png" alt="order_receipt_001.paper" width="200" height="200"></br></details>

## Language Specific READMEs

* [English](README.md)
* [한국어](README.ko.md)
