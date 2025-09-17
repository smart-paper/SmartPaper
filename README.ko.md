# 스마트페이퍼

스마트페이퍼에 대한 정보를 제공하고 공유하는 저장소입니다.

자연을 보호해야 자연도 여러분들을 보호합니다!</br>
모든 비스페놀로부터 자유로워지세요...

단일 SmartPaper 인스턴스 내에서 **여러 종류의 지류** (예: 주문서, 전표, 영수증, 번호표, 쿠폰, 티켓)를 지원하도록 기능이 대폭 확장되어 활용도가 크게 증가했습니다.
AES 암호화 지원을 통해 보안 전송 및 저장이 가능합니다.

개인, 기업, 공공기관, 정부 등 누구나 제한 없이 자유롭게 이용할 수 있습니다.

## 스마트페이퍼 데이터 모델

SmartPaper 데이터 모델은 `202506221515` 버전 코드부터 여러 종류의 지류를 지원하도록 크게 업데이트되었습니다.

### 데이터 모델 변경

* **새로운 SmartPaper 구조**: 이제 기존 SmartPaper 구조의 일부와 `SmartRecord` 목록으로 구성됩니다. 이 변경을 통해 단일 용지 내에서 여러 지류 항목을 관리할 수 있게 되었습니다.
* **이름 변경**: 새로운 모델의 명확성을 위해 `SmartPaperItem`이 `SmartRecordLine`으로 이름이 변경되었습니다.

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

## 기능 (Features)

이 문서는 **SmartPaper**의 주요 기능과 설정 옵션을 설명합니다.

---

### 핵심 기능

1.  **용지 크기 및 레이아웃**:
    * **너비**: 픽셀 단위로 설정 가능하며, 출력 화면보다 클 경우 자동으로 화면 크기에 맞춰 조정됩니다.
    * **높이**: 아이템 설정에 따라 동적으로 결정됩니다.
2.  **테두리**: 용지 전체를 감싸는 단일 실선 테두리를 지원합니다. (다른 종류는 향후 지원 예정)
3.  **보안 지원**: 용지가 저장되는 URL에 대한 지원 및 용지 데이터 암호화를 지원합니다.
4.  **저장 기능**: 전용 뷰어에서 용지의 수동 및 자동 저장을 지원합니다. 여러 지류에 대해 '하나로' 또는 '개별로' 저장 가능합니다.
5.  **다양한 라인 포맷**:
    * **기본**: 텍스트, 이미지, 텍스트&이미지, 이미지&텍스트, 바코드, QR코드
    * **특수**: 패딩스트링(하나의 라인에 여러 개의 텍스트 지원)
    * **상호작용**: 리스트, 버튼, 타이머 (지원 예정이며 실시간으로 데이터 갱신 가능)

---

### 지원되는 콘텐츠 유형 및 설정

SmartPaper는 다양한 콘텐츠 유형을 지원하며, 각 유형에는 특정 설정 옵션을 지원합니다.

#### 공통 설정

* **정렬 (Alignment)**: 섹션 내에서의 위치를 정의합니다.
    * `topLeft (0x11)`, `topCenter (0x110)`, `topRight (0x12)`
    * `centerLeft (0x101)`, `center (0x100)`, `centerRight (0x102)`
    * `bottomLeft (0x21)`, `bottomCenter (0x120)`, `bottomRight (0x22)`
    * `none (0)`

#### 배경 이미지 (Background Image)

* **bgImageSrc**: 배경 이미지의 URL 입니다.
* **bgImageOpacity**: 배경 이미지의 투명도(불투명도)를 설정합니다. 0.0 (완전 투명)에서 1.0 (완전 불투명) 사이의 값을 가집니다.
* **smartPaperImageType**: 배경 이미지가 라인 영역에 어떻게 맞춰지거나 반복될지 정의합니다.
    * BoxFit 계열 (이미지 크기 조절 방식)
	    * none: 이미지를 원래 크기 그대로 표시합니다. 영역보다 크면 잘리고, 작으면 빈 공간이 생깁니다.
	    * cover: 이미지의 가로세로 비율을 유지하면서 영역을 완전히 덮도록 확대/축소합니다. 이미지의 일부가 잘릴 수 있습니다. (대부분의 배경 이미지에 권장)
	    * contain: 이미지의 가로세로 비율을 유지하면서 영역 안에 이미지가 모두 보이도록 확대/축소합니다. 이미지 주변에 빈 공간(레터박스/필러박스)이 생길 수 있습니다.
	    * fill (stretch): 이미지의 가로세로 비율을 무시하고 영역을 가득 채우도록 늘리거나 줄입니다. 이미지가 왜곡될 수 있습니다.
	    * fitWidth: 이미지의 가로세로 비율을 유지하면서 너비를 영역에 맞춥니다. 높이는 이미지 비율에 따라 조정됩니다.
	    * fitHeight: 이미지의 가로세로 비율을 유지하면서 높이를 영역에 맞춥니다. 너비는 이미지 비율에 따라 조정됩니다.
	    * scaleDown: 이미지가 영역보다 작으면 none처럼 표시하고, 크면 contain처럼 영역에 맞춰 축소합니다.
    * ImageRepeat 계열 (이미지 반복 방식)
	    * repeat: 이미지를 원본 크기 그대로 영역이 채워질 때까지 가로세로로 반복하여 표시합니다.
	    * repeatX: 이미지를 원본 크기 그대로 영역이 채워질 때까지 가로로만 반복하여 표시합니다.
	    * repeatY: 이미지를 원본 크기 그대로 영역이 채워질 때까지 세로로만 반복하여 표시합니다.

#### 콘텐츠 유형 (`type` 속성 기준)

1.  **텍스트 (`type = 1`)**
    * **텍스트 스타일**:
        * `폰트 스타일`: `normal (0x00000001)`, `italic (0x00000002)`
        * `폰트 굵기`: `bold (0x00000100)`
        * `텍스트 장식`: `underline (0x00010000)`, `overline (0x00020000)`, `lineThrough (0x00040000)`
        * 조합도 지원 (예: `normalAndBold`, `italicAndUnderline`).
    * **속성**: `text`, `fontSize`, `textAlignment`, `textMaxLines`, `textColor`, `textBgColor`

2.  **이미지 (`type = 0`)**
    * **속성**: `imageWidth`, `imageHeight`, `imageSrc` (URL)

3.  **이미지 & 텍스트 (`type = 2`)**
    * 이미지는 왼쪽에 텍스트는 오른쪽에 배치

4.  **텍스트 & 이미지 (`type = 3`)**
    * 텍스트는 왼쪽에 이미지는 오른쪽에 배치

5.  **바코드 (`type = 5`)**
    * **속성**: `text` (바코드 데이터), `imageWidth`, `imageHeight`

6.  **QR 코드 (`type = 7`)**
    * **속성**: `text` (QR 코드 데이터), `imageWidth`, `imageHeight`

7.  **구분선 (`type = 4`)**
    * **스타일**:
        * `pipe (0) [|]`, `slash (1) [/]`, `backSlash (2) [\\]`, `hyphen (3) [-]`, `sharp (4) [#]`
        * `plus (5) [+]`, `star (6) [*]`, `exclamation (7) [!]`, `at (8) [@]`, `dollar (9) [$]`
        * `percent (10) [%]`, `caret (11) [^]`, `ampersand (12) [&]`, `blank (13) [ ]`
        * `equal (14) [=]`, `underscore (15) [_]`, `dot (16) [.]`, `comma (17) [,]`
        * `custom (99) []`, `none (-1) []`
    * **속성**: `fontSize`

---

### 고급 텍스트 구성: 패드 문자열 (`type = text`)

하나의 줄에 여러 텍스트 세그먼트를 구성하기 위해 사용되며, 비율적 크기 조정 또는 패딩과 함께 사용됩니다.

`정렬 유형 (Alignment Type)` (우선 적용) 및 `패드 유형 (Pad Type)`을 지원합니다.

* **문자열 구분자**:
    * `STRING_FORMAT_SEPARATOR ([|SFS|])`
    * `STRING_END_OF ([|SEO|])`

#### 패드 문자열 형식:

1.  **정렬 유형 (Alignment Type)**
    * **형식**: `[text]|SFS|[padFlex]|SFS|[textAlignment]|SEO|`
    * **속성**:
        * `text`: 텍스트 세그먼트의 내용.
        * `padFlex`: 여러 'Pad String' 항목이 있을 때 크기 조정을 위한 비례 정수 값.
        * `textAlignment`: 정렬 값.

2.  **패드 유형 (Pad Type)**
    * **형식**: `[text]|SFS|[padFlex]|SFS|[padType]|SFS|[padWidth]|SFS|[padText]|SEO|`
    * **속성**:
        * `text`: 텍스트 세그먼트의 내용.
        * `padFlex`: 여러 'Pad String' 항목이 있을 때 크기 조정을 위한 비례 정수 값.
        * `padType`: `leftPad (0)`, `rightPad (1)`
        * `padWidth`: 패드 너비.
        * `padText`: 패드를 채울 문자.

## 사용 방법 (C# 소스 코드)

```
SmartPaper smartPaper = new();
SmartRecord smartRecord = new();
SmartRecordLine smartRecordLine;
...
smartRecord.items.add(smartRecordLine);
...
smartPaper.smartRecordList.add(smartRecord);
```

* 용지 크기 (PaperSize)

```
public const double defaultPaperWidth = 500; // 기본 500
```

* 배경이미지 (Background Image)

```
smartRecord.bgImageSrc = "Background Image URL";
smartRecord.bgImageOpacity = 0.2;
smartRecord.smartPaperImageType = SmartPaperImageType.repeat;
```

* 외곽선 (Outline)

```
smartRecord.outlineWidth = 2.0;
```

* 유형 (Type)

```
smartRecordLine.type = SmartRecordLineType.image;
```

* 정렬 (Alignment)

```
smartRecordLine.textAlignment = SmartRecordLineAlignment.center;
smartRecordLine.imageAlignment = SmartRecordLineAlignment.center;
```

* 텍스트 (Text)

```
smartRecordLine.textStyle = SmartRecordLineTextStyle.bold;
smartRecordLine.text = "Smart Paper";
smartRecordLine.fontSize = 16.0;
smartRecordLine.textAlignment = SmartRecordLineAlignment.center;
smartRecordLine.textMaxLines = null; // Unlimit
smartRecordLine.textColor = DataManager.IntToColorHex(4278190080); // #FF000000 (#ARGB)
smartRecordLine.textBgColor = DataManager.IntToColorHex(4294967295); // #FFFFFFFF (#ARGB)
```

* 패드 문자열 (Pad String)

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

* 이미지 (Image)

```
smartRecordLine = SmartPaperHelper.Image("https://image.example.com/paper.png", imageWidth: 360, imageHeight: 240, SmartRecordLineAlignment.center);
```

* 이미지 & 텍스트 (Image & Text)

```
smartRecordLine = SmartPaperHelper.ImageAndText("https://image.example.com/paper.png", imageWidth: 360, imageHeight: 240, text: "SmartPaper", textAlignment: SmartRecordLineAlignment.center, fontSize: 16.0, textStyle: SmartRecordLineTextStyle.normal);
```

* 텍스트 & 이미지 (Text & Image)

```
smartRecordLine = SmartPaperHelper.TextAndImage("https://image.example.com/paper.png", imageWidth: 360, imageHeight: 240, text: "SmartPaper", textAlignment: SmartRecordLineAlignment.center, fontSize: 16.0, textStyle: SmartRecordLineTextStyle.normal);
```

* 구분선 (Divider)

```
smartRecordLine = SmartPaperHelper.Divider(dividerStyle: SmartRecordLineDividerStyle.equal, fontSize: 15.0);
smartRecord.items.Add(smartRecordLine);
```

* 바코드 (Barcode)

```
smartRecordLine = SmartPaperHelper.Barcode(text: "126af11e3355", imageWidth: paperWidth, imageHeight: 100);
smartRecord.items.Add(smartRecordLine);
```

* QR 코드 (QR Code)

```
smartRecordLine = SmartPaperHelper.QrCode(text: "126af11e3355", imageWidth: paperWidth, imageHeight: 100);
smartRecord.items.Add(smartRecordLine);
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

* 실시간 생성

> [영화 티켓 & 주차권](https://app.publicplatform.co.kr/?/smart_paper?type=paper&vendor=theater&savable=true) 링크

> [대기순번표](https://app.publicplatform.co.kr/?/smart_paper?type=paper&vendor=bank_waiting_number&savable=true) 링크

* 일반 URLs

> [축제초대장 & 주차권](https://app.publicplatform.co.kr/?/smart_paper?type=url&url=https%3A%2F%2Fsmart-paper.github.io%2FSmartPaper%2Fsamples%2Ffestival_ticket_and_parking_ticket_001.json&autoSave=false) 링크</br><details><summary>QR 코드 보기</summary><img src="https://smart-paper.github.io/SmartPaper/samples/festival_ticket_and_parking_ticket_001.json.png" alt="festival_ticket_and_parking_ticket_001.json" width="200" height="200"></br></details>

> [영수증 & 주차권](https://app.publicplatform.co.kr/?/smart_paper?type=url&url=https%3A%2F%2Fsmart-paper.github.io%2FSmartPaper%2Fsamples%2Forder_receipt_and_parking_ticket_001.json&autoSave=false) 링크</br><details><summary>QR 코드 보기</summary><img src="https://smart-paper.github.io/SmartPaper/samples/order_receipt_and_parking_ticket_001.json.png" alt="order_receipt_and_parking_ticket_001.json" width="200" height="200"></br></details>

> [주문지](https://app.publicplatform.co.kr/?/smart_paper?type=url&url=https%3A%2F%2Fsmart-paper.github.io%2FSmartPaper%2Fsamples%2Forder_form_001.json&autoSave=false) 링크</br><details><summary>QR 코드 보기</summary><img src="https://smart-paper.github.io/SmartPaper/samples/order_form_001.json.png" alt="order_form_001.json" width="200" height="200"></br></details>

> [주문서](https://app.publicplatform.co.kr/?/smart_paper?type=url&url=https%3A%2F%2Fsmart-paper.github.io%2FSmartPaper%2Fsamples%2Forder_sheet_001.json&autoSave=false) 링크</br><details><summary>QR 코드 보기</summary><img src="https://smart-paper.github.io/SmartPaper/samples/order_sheet_001.json.png" alt="order_sheet_001.json" width="200" height="200"></br></details>

> [영수증](https://app.publicplatform.co.kr/?/smart_paper?type=url&url=https%3A%2F%2Fsmart-paper.github.io%2FSmartPaper%2Fsamples%2Forder_receipt_001.json&autoSave=false) 링크</br><details><summary>QR 코드 보기</summary><img src="https://smart-paper.github.io/SmartPaper/samples/order_receipt_001.json.png" alt="order_receipt_001.json" width="200" height="200"></br></details>

> [번호표](https://app.publicplatform.co.kr/?/smart_paper?type=url&url=https%3A%2F%2Fsmart-paper.github.io%2FSmartPaper%2Fsamples%2Fnumber_ticket_001.json&autoSave=false) 링크</br><details><summary>QR 코드 보기</summary><img src="https://smart-paper.github.io/SmartPaper/samples/number_ticket_001.json.png" alt="number_ticket_001.json" width="200" height="200"></br></details>

* 보안 URLs (PIN: 1234)

> [영수증 & 주차권](https://app.publicplatform.co.kr/?/smart_paper?type=surl&url=%2F3C0KcmfZj69Bsl%2FDBJ29kPlwH68JWEdWujn%2FLEFZdn9i1UokVxJVTlmZusCwprSY21ikMyvjQu5UGqLwdDw7E9m%2F6kZUiOg7fhzrzDQFBuzsr8In%2Fa2sI73OTPTt%2F2eZIIVz4c%2BNtOagUq%2BPSYvOtHO&iv=EBESExQVFhcYGRob&keyBits=256&autoSave=false) 링크</br><details><summary>QR 코드 보기</summary><img src="https://smart-paper.github.io/SmartPaper/samples/secure/order_receipt_and_parking_ticket_001.paper.png" alt="order_receipt_001.paper" width="200" height="200"></br></details>

> [주문지](https://app.publicplatform.co.kr/?/smart_paper?type=surl&url=%2F3C0KcmfZj69Bsl%2FDBJ29kPlwH68JWEdWujn%2FLEFZdn9i1UokVxJVTlmZusCwprSY21ikMyvjQu5UGqLwdDk5l5uyeldPGy%2B6NdmvE8RrSAXGv6D9vsc6bEuDvQ%3D&iv=EBESExQVFhcYGRob&keyBits=256&autoSave=false) 링크</br><details><summary>QR 코드 보기</summary><img src="https://smart-paper.github.io/SmartPaper/samples/secure/order_form_001.paper.png" alt="order_form_001.paper" width="200" height="200"></br></details>

> [주문서](https://app.publicplatform.co.kr/?/smart_paper?type=surl&url=%2F3C0KcmfZj69Bsl%2FDBJ29kPlwH68JWEdWujn%2FLEFZdn9i1UokVxJVTlmZusCwprSY21ikMyvjQu5UGqLwdDx4Ulm4oZdPXPg%2BcZzqzCzKuamv4IudA0PFVW2JBW%2B&iv=EBESExQVFhcYGRob&keyBits=256&autoSave=false) 링크</br><details><summary>QR 코드 보기</summary><img src="https://smart-paper.github.io/SmartPaper/samples/secure/order_sheet_001.paper.png" alt="order_sheet_001.paper" width="200" height="200"></br></details>

> [영수증](https://app.publicplatform.co.kr/?/smart_paper?type=surl&url=%2F3C0KcmfZj69Bsl%2FDBJ29kPlwH68JWEdWujn%2FLEFZdn9i1UokVxJVTlmZusCwprSY21ikMyvjQu5UGqLwdDw7E9m%2F6kZUnL%2BuIlzrzLeD3sqdYkZeWZK74rFU76DX%2F8%3D&iv=EBESExQVFhcYGRob&keyBits=256&autoSave=false) 링크</br><details><summary>QR 코드 보기</summary><img src="https://smart-paper.github.io/SmartPaper/samples/secure/order_receipt_001.paper.png" alt="order_receipt_001.paper" width="200" height="200"></br></details>

## Language Specific READMEs

* [English](README.md)
* [한국어](README.ko.md)
