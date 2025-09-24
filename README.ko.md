# 스마트페이퍼

스마트페이퍼에 대한 정보를 제공하고 공유하는 저장소입니다.

자연을 보호해야 자연도 여러분들을 보호합니다!</br>
모든 비스페놀로부터 자유로워지세요...

단일 SmartPaper 인스턴스 내에서 **여러 종류의 지류** (예: 주문서, 전표, 영수증, 번호표, 쿠폰, 티켓)를 지원하도록 기능이 대폭 확장되어 활용도가 크게 증가했습니다.
AES 암호화 지원을 통해 보안 전송 및 저장이 가능합니다.

이 프로젝트는 이중 라이선스 모델을 채택하고 있습니다.

* **GPLv3**: 개인 및 비영리 목적의 사용에 적용됩니다. 이 라이선스에 따라 소스 코드를 사용하려면 파생된 작업물 역시 GPLv3로 공개해야 합니다.
* **상용 라이선스**: GPLv3의 의무를 따르지 않고자 하는 공공기관, 영리기업 등 단체는 별도의 상용 라이선스를 구매해야 합니다. 단, 비영리 목적이라도 전문적인 기술 지원이나 맞춤형 개발 등 협업을 원할 경우 상용 라이선스에 대해 문의할 수 있습니다. 상용 라이선스에 대한 문의는 [icitlabs@gmail.com]으로 연락 주시기 바랍니다.

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
| ...                                                         |
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
    * **높이**: 스마트페이퍼 구성에 따라 동적으로 결정됩니다.
2.  **테두리**: 용지 전체를 감싸는 단일 실선 테두리를 지원합니다. (다른 종류는 향후 지원 예정)
3.  **보안 지원**: 용지가 저장되는 URL에 대한 지원 및 용지 데이터 암호화를 지원합니다. 사용자 정의 PIN 코드 지원으로 
4.  **저장 기능**: 전용 뷰어에서 용지의 수동 및 자동 저장을 지원합니다. 여러 지류에 대해 '하나로' 또는 '개별로' 저장 가능합니다.
5.  **다양한 라인 포맷**:
    * **기본**: 텍스트, 이미지, 텍스트&이미지, 이미지&텍스트, 바코드, QR코드
    * **특수**: 패딩스트링(하나의 라인에 여러 개의 텍스트 지원)
    * **상호작용**: 리스트, 버튼, 타이머 (지원 예정이며 실시간으로 데이터 갱신 가능)
    * **멀티미디어**: 애니메이션 이미지(GIF, APNG), 비디오, 오디오 (지원 예정)
    * **문서**: PDF (지원 예정), DOC(X), PPT(X), XLS(X), HWP(X) (검토 중)
    * **알람**: 대기 순번, 쿠폰 마감, 예약/일정 등 다양한 알림 제공 (지원 예정)
    * **URL**: 외부 웹 페이지나 다른 스마트페이퍼 문서로 직접 연결되는 링크 라인을 추가하여 정보 연계 및 확장 가능 (지원 예정)

### 지원되는 URL 파라미터

다양한 파라미터를 통해 여러 데이터 유형을 처리하는 유연성을 보여줍니다.

1.  **'type' 파라미터**
    * **type=url**: URL 파라미터에 포함된 스마트페이퍼 URL을 디코딩하여 사용합니다.
    * **type=surl**: 암호화된 스마트페이퍼 URL과 함께 iv (초기화 벡터), keyBits (키 길이) 등 복호화에 필요한 파라미터를 전달받아 처리합니다.
    * **type=paper**: Base64로 인코딩된 데이터를 디코딩하여 SmartPaper 객체로 역직렬화합니다.

2.  **'paper' 파라미터**
    * **paper=json**: 자바스크립트 객체 표기법 (JavaScript Object Notation), 기본값
    * **paper=xml**: 확장 가능한 마크업 언어 (eXtensible Markup Language)
    * **paper=csv**: 콤마 구분 값 (Comma-Separated Values)
    * **paper=yaml**: YAML은 마크업 언어가 아니다 (YAML Ain't Markup Language)
    * **paper=protobuf**: 프로토콜 버퍼 (Protocol Buffers)
    * **paper=bin**: 바이너리 데이터 (Binary data)
    * **paper=raw**: 스마트페이퍼의 원시 데이터 (Raw data)

3. **부가 기능 파라미터**
    * **isAutoSave, isSavable**: 스마트페이퍼의 자동 저장 및 저장 가능 여부를 제어합니다.
    * **isPinSetting**: 핀(PIN) 설정이 필요한 보안 문서를 다룰 때 사용됩니다.
    * **autoRefresh**: 자동 새로고침 간격을 밀리초(ms) 단위로 지정합니다. 이 파라미터가 0보다 크면 실시간으로 데이터를 갱신합니다.
    * **isAutoCopy**: 스마트페이퍼 URL을 사용자의 클립보드에 자동으로 복사하는 기능을 제공합니다.

URL을 통해 **정적 데이터(json)**는 물론, 동적 상호작용(autoRefresh) 및 **보안 기능(surl, pinSetting)**까지 완벽하게 처리하는 정교하고 확장성 있는 시스템으로 구현되어 있습니다.

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

1.  **이미지 (`type = 0`)**
    * **속성**: `imageWidth`, `imageHeight`, `imageSrc` (URL)

2.  **텍스트 (`type = 1`)**
    * **텍스트 스타일**:
        * `폰트 스타일`: `normal (0x00000001)`, `italic (0x00000002)`
        * `폰트 굵기`: `bold (0x00000100)`
        * `텍스트 장식`: `underline (0x00010000)`, `overline (0x00020000)`, `lineThrough (0x00040000)`
        * 조합도 지원 (예: `normalAndBold`, `italicAndUnderline`).
    * **속성**: `text`, `textSize`, `textAlignment`, `textMaxLines`, `textColor`, `textBgColor`

3.  **이미지 & 텍스트 (`type = 2`)**
    * 이미지는 왼쪽에 텍스트는 오른쪽에 배치

4.  **텍스트 & 이미지 (`type = 3`)**
    * 텍스트는 왼쪽에 이미지는 오른쪽에 배치

5.  **구분선 (`type = 4`)**
    * **스타일**:
        * `pipe (0) [|]`, `slash (1) [/]`, `backSlash (2) [\\]`, `hyphen (3) [-]`, `sharp (4) [#]`
        * `plus (5) [+]`, `star (6) [*]`, `exclamation (7) [!]`, `at (8) [@]`, `dollar (9) [$]`
        * `percent (10) [%]`, `caret (11) [^]`, `ampersand (12) [&]`, `blank (13) [ ]`
        * `equal (14) [=]`, `underscore (15) [_]`, `dot (16) [.]`, `comma (17) [,]`
        * `custom (99) []`, `none (-1) []`
    * **속성**: `textSize`

6.  **바코드 (`type = 5`)**
    * **속성**: `text` (바코드 데이터), `imageWidth`, `imageHeight`

7.  **QR 코드 (`type = 6`)**
    * **속성**: `text` (QR 코드 데이터), `imageWidth`, `imageHeight`

8.  **리스트 (`type = 7`)**
    * **속성**: `listType`, `listTitle`, `listWidth`, `listHeight`, `listTitleColor`, `listTitleBgColor`, `listTextColor`, `listTextBgColor`, `listItems`

9.  **버튼 (`type = 8`)**
    * **속성**: `buttonAction`, `buttonRestfulApi`, `buttonText`, `buttonWidth`, `buttonHeight`, `buttonTextColor`, `buttonTextBgColor`

10.  **타이머 (`type = 9`)**
    * **속성**: `timerType`, `timerAction`, `timerRestfulApi`, `timerText`, `timerInMillis`

11.  **비디오 (`type = 10`)**
    * **속성**: `videoTitle`, `videoUrl`, `videoWidth`, `videoHeight`

12.  **오디오 (`type = 11`)**
    * **속성**: `audioTitle`, `audioUrl`

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
smartRecordLine.textSize = 16.0;
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
smartRecordLine = SmartPaperHelper.MakePadStringLine(padStringList, textStyle: SmartRecordLineTextStyle.normal, textSize: 21.0, textColor: "#FFFFFFFF", textBgColor: "#FF000000");
smartRecord.items.Add(smartRecordLine);
```

* 이미지 (Image)

```
smartRecordLine = SmartPaperHelper.Image("https://image.example.com/paper.png", imageWidth: 360, imageHeight: 240, SmartRecordLineAlignment.center);
```

* 이미지 & 텍스트 (Image & Text)

```
smartRecordLine = SmartPaperHelper.ImageAndText("https://image.example.com/paper.png", imageWidth: 360, imageHeight: 240, text: "SmartPaper", textAlignment: SmartRecordLineAlignment.center, textSize: 16.0, textStyle: SmartRecordLineTextStyle.normal);
```

* 텍스트 & 이미지 (Text & Image)

```
smartRecordLine = SmartPaperHelper.TextAndImage("https://image.example.com/paper.png", imageWidth: 360, imageHeight: 240, text: "SmartPaper", textAlignment: SmartRecordLineAlignment.center, textSize: 16.0, textStyle: SmartRecordLineTextStyle.normal);
```

* 구분선 (Divider)

```
smartRecordLine = SmartPaperHelper.Divider(dividerStyle: SmartRecordLineDividerStyle.equal, textSize: 15.0);
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

> [영화 티켓 & 주차권](https://app.publicplatform.co.kr/?/smart_paper?type=paper&paper=sample&vendor=theater&savable=true) 링크

> [대기순번표](https://app.publicplatform.co.kr/?/smart_paper?type=paper&paper=sample&vendor=bank_waiting_number&savable=true) 링크

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
