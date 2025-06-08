# 스마트페이퍼

스마트페이퍼에 대한 정보를 제공하고 공유하는 저장소입니다.

자연을 보호해야 자연도 여러분들을 보호합니다!</br>
모든 비스페놀로부터 자유로워지세요...

주문지, 주문서, 영수증, 번호표/번호태그, 쿠폰, 티켓 등 다양한 종류의 용지를 지원합니다.</br>
AES 암호화(기본 256 비트) 지원을 통해 안전한 전송 및 저장이 가능합니다.

## 기능

1. 용지 크기 설정: 용지의 너비로 Pixel 단위 (출력 화면보다 큰 경우 출력 화면 크기로 자동 조절 )
2. 테투리: 용지 전체를 감싸는 테두리로 현재 실선만 지원 (다른 타입 지원 예정)
3. 지원되는 유형
    1. 이미지
    2. 텍스트
    3. 이미지 & 텍스트
    4. 텍스트 & 이미지
    5. 구분선
    6. 바코드
    7. QR 코드
4. 보안 지원: 용지가 저장된 URL 및 용지 데이터 암호화 지원
5. 저장 기능: 전용 뷰어에서 용지를 수동 및 자동 저장 지원

* 용지 크기 (PaperSize)
> paperWidth: 용지 너비
> 용지 높이는 항목 구성에 의해 결정됩니다.

* 테두리 (Outline)
> 테두리 타입: 실선, 점선, 파선, 굵은 선, 가는 선, 이중 선 중에서 현재는 실선만 지원</br>
> outlineWidth: 0보다 큰 실수

* 유형 (Type)
> image(0), text(1), imageAndText(2), textAndImage(3), divider(4), barcode(5), qrcode(6)

* 정렬 (Alignment)
> 상단: topLeft(0x11), topCenter(0x110), topRight(0x12)</br>
> 중앙: centerLeft(0x101), center(0x100), centerRight(0x102)</br>
> 하단: bottomLeft(0x21), bottomCenter(0x120), bottomRight(0x22)</br>
> 설정 안함: none(0)

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
> 폰트 크기</br>
> **[textAlignment]**</br>
> 정렬 값</br>
> **[textMaxLines]**</br>
> 텍스트 최대 라인 수</br>
> **[textColor]**</br>
> 텍스트 색상</br>
> **[textBgColor]**</br>
> 텍스트 배경 색상 

* 패드 문자열 (Pad String): type = text
> 패드를 가진 텍스트를 구성하기 위한 아이템</br>
> 여러 개의 아이템으로 구성하면 한 줄에 여러 개의 텍스트 출력 가능</br>
> '정렬 타입'과 '패드 타입'을 지원하며 '정렬 타입'이 우선 됨</br></br>
> String Divider: STRING_FORMAT_SEPARATOR([|SFS|]), STRING_END_OF([|SEO|])</br></br>
> **정렬 타입 (Alignment Type)**</br>
> [text]STRING_FORMAT_SEPARATOR[padFlex]STRING_FORMAT_SEPARATOR[textAlignment]STRING_END_OF</br>
> **[text]**</br>
> 텍스트</br>
> **[padFlex]**</br>
> 여러 개의 'Pad String'으로 구성될 때 다른 'Pad String'의 크기에 대한 비례되는 정수 값</br>
> **[textAlignment]**</br>
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

* 구분선 (Divider): type = divider
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

## 사용 방법 (C# 소스 코드)

```
SmartPaper smartPaper;
SmartPaperItem smartPaperItem;
```

* 용지 크기 (PaperSize)

```
paper.paperWidth = 500; // 기본 500
```

* 테두리 (Outline)

```
paper.outlineWidth = 2.0;
```

* 유형 (Type)

```
smartPaperItem.type = SmartPaperItemType.image;
```

* 정렬 (Alignment)

```
smartPaperItem.textAlignment = SmartPaperItemAlignment.center;
smartPaperItem.imageAlignment = SmartPaperItemAlignment.center;
```

* 텍스트 (Text)

```
smartPaperItem.textStyle = SmartPaperItemTextStyle.bold;
smartPaperItem.text = "Smart Paper";
smartPaperItem.fontSize = 16.0;
smartPaperItem.textAlignment = SmartPaperItemAlignment.center;
smartPaperItem.textMaxLines = null; // Unlimit
smartPaperItem.textColor = DataManager.IntToColorHex(4278190080); // #FF000000 (#ARGB)
smartPaperItem.textBgColor = DataManager.IntToColorHex(4294967295); // #FFFFFFFF (#ARGB)
```

* 패드 문자열 (Pad String)

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

* 이미지 (Image)

```
smartPaperItem = SmartPaperHelper.Image("https://image.example.com/paper.png", imageWidth: 360, imageHeight: 240, SmartPaperItemAlignment.center);
```

* 이미지 & 텍스트 (Image & Text)

```
smartPaperItem = SmartPaperHelper.ImageAndText("https://image.example.com/paper.png", imageWidth: 360, imageHeight: 240, text: "SmartPaper", textAlignment: SmartPaperItemAlignment.center, fontSize: 16.0, textStyle: SmartPaperItemTextStyle.normal);
```

* 텍스트 & 이미지 (Text & Image)

```
smartPaperItem = SmartPaperHelper.TextAndImage("https://image.example.com/paper.png", imageWidth: 360, imageHeight: 240, text: "SmartPaper", textAlignment: SmartPaperItemAlignment.center, fontSize: 16.0, textStyle: SmartPaperItemTextStyle.normal);
```

* 구분선 (Divider)

```
smartPaperItem = SmartPaperHelper.Divider(dividerStyle: SmartPaperItemDividerStyle.equal, fontSize: 15.0);
smartPaper.items.Add(smartPaperItem);
```

* 바코드 (Barcode)

```
smartPaperItem = SmartPaperHelper.Barcode(text: "126af11e3355", imageWidth: paperWidth, imageHeight: 100);
smartPaper.items.Add(smartPaperItem);
```

* QR 코드 (QR Code)

```
smartPaperItem = SmartPaperHelper.QrCode(text: "126af11e3355", imageWidth: paperWidth, imageHeight: 100);
smartPaper.items.Add(smartPaperItem);
```

* 샘플 JSON 생성

```
SmartPaper smartPaper = Example001.GeneratePaper();
string json = SmartPaper.toJson(smartPaper);
```

* 암호화된 JSON 생성

```
SmartPaper smartPaper = Example001.GeneratePaper();
string jsonData = SmartPaper.toJson(smartPaper);
string pin = "abc123#@$"; // PIN은 사용자가 실제로 입력하는 값입니다.
byte[] keyBytes = SmartPaperManager.GenerateDeterministicKeyFromPin(pin);
byte[] nonceBytes = SmartPaperManager.GenerateUniqueNonce();

string securePayload = SmartPaperManager.EncryptData(jsonData, keyBytes, nonceBytes);	// Base64로 인코딩
```

* URL 생성

```
string paperUrl = "https://paper.example.com/order_receipt_001.json";
string? url = SmartPaperManager.GenerateUrl(paperUrl);
```

* 보안 URL 생성

```
string paperUrl = "https://paper.example.com/order_receipt_001.paper";
string pin = "abc123#@$"; // PIN은 사용자가 실제로 입력하는 값입니다.
byte[] keyBytes = SmartPaperManager.GenerateDeterministicKeyFromPin(pin);
byte[] nonceBytes = SmartPaperManager.GenerateUniqueNonce();

string? surl = SmartPaperManager.EncryptAndGenerateUrl(paperUrl, keyBytes, nonceBytes);
```

## 테스트 뷰어

생성한 스마트페이퍼를 테스트할 수 있습니다.

<a href="https://www.publicplatform.co.kr/smartpaper/" target="_blank">
  🔗 스마트페이퍼 뷰어 열기
</a>

## 샘플

* 일반 URLs

> [주문지](https://app.publicplatform.co.kr/?/smart_paper?type=url&url=https%3A%2F%2Fsmart-paper.github.io%2FSmartPaper%2Fsamples%2Forder_form_001.json&autoSave=true) 링크</br><details><summary>QR 코드 보기</summary><img src="https://smart-paper.github.io/SmartPaper/samples/order_form_001.json.png" alt="order_form_001.json" width="200" height="200"></br></details>

> [주문서](https://app.publicplatform.co.kr/?/smart_paper?type=url&url=https%3A%2F%2Fsmart-paper.github.io%2FSmartPaper%2Fsamples%2Forder_sheet_001.json&autoSave=true) 링크</br><details><summary>QR 코드 보기</summary><img src="https://smart-paper.github.io/SmartPaper/samples/order_sheet_001.json.png" alt="order_sheet_001.json" width="200" height="200"></br></details>

> [영수증](https://app.publicplatform.co.kr/?/smart_paper?type=url&url=https%3A%2F%2Fsmart-paper.github.io%2FSmartPaper%2Fsamples%2Forder_receipt_001.json&autoSave=true) 링크</br><details><summary>QR 코드 보기</summary><img src="https://smart-paper.github.io/SmartPaper/samples/order_receipt_001.json.png" alt="order_receipt_001.json" width="200" height="200"></br></details>

> [번호표](https://app.publicplatform.co.kr/?/smart_paper?type=url&url=https%3A%2F%2Fsmart-paper.github.io%2FSmartPaper%2Fsamples%2Fnumber_ticket_001.json&autoSave=true) 링크</br><details><summary>QR 코드 보기</summary><img src="https://smart-paper.github.io/SmartPaper/samples/number_ticket_001.json.png" alt="number_ticket_001.json" width="200" height="200"></br></details>

* 보안 URLs (PIN: 1234)

> [주문지](https://app.publicplatform.co.kr/?/smart_paper?type=surl&url=%2F3C0KcmfZj69Bsl%2FDBJ29kPlwH68JWEdWujn%2FLEFZdn9i1UokVxJVTlmZusCwprSY21ikMyvjQu5UGqLwdDk5l5uyeldPGy%2B6NdmvE8RrSAXGv6D9vsc6bEuDvQ%3D&iv=EBESExQVFhcYGRob&keyBits=256&autoSave=false) 링크</br><details><summary>QR 코드 보기</summary><img src="https://smart-paper.github.io/SmartPaper/samples/secure/order_form_001.paper.png" alt="order_form_001.paper" width="200" height="200"></br></details>

> [주문서](https://app.publicplatform.co.kr/?/smart_paper?type=surl&url=%2F3C0KcmfZj69Bsl%2FDBJ29kPlwH68JWEdWujn%2FLEFZdn9i1UokVxJVTlmZusCwprSY21ikMyvjQu5UGqLwdDx4Ulm4oZdPXPg%2BcZzqzCzKuamv4IudA0PFVW2JBW%2B&iv=EBESExQVFhcYGRob&keyBits=256&autoSave=false) 링크</br><details><summary>QR 코드 보기</summary><img src="https://smart-paper.github.io/SmartPaper/samples/secure/order_sheet_001.paper.png" alt="order_sheet_001.paper" width="200" height="200"></br></details>

> [영수증](https://app.publicplatform.co.kr/?/smart_paper?type=surl&url=%2F3C0KcmfZj69Bsl%2FDBJ29kPlwH68JWEdWujn%2FLEFZdn9i1UokVxJVTlmZusCwprSY21ikMyvjQu5UGqLwdDw7E9m%2F6kZUnL%2BuIlzrzLeD3sqdYkZeWZK74rFU76DX%2F8%3D&iv=EBESExQVFhcYGRob&keyBits=256&autoSave=false) 링크</br><details><summary>QR 코드 보기</summary><img src="https://smart-paper.github.io/SmartPaper/samples/secure/order_receipt_001.paper.png" alt="order_receipt_001.paper" width="200" height="200"></br></details>

## Language Specific READMEs

* [English](README.md)
* [한국어](README.ko.md)
