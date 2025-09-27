# 스마트페이퍼 (SmartPaper) 🛡️

스마트페이퍼 데이터 모델 및 관련 로직을 제공하고 공유하는 저장소입니다.

자연을 보호해야 자연도 여러분들을 보호합니다! 🌳</br>
모든 비스페놀로부터 자유로워지세요... 🚫

**SmartPaper**는 종이 문서(영수증, 티켓 등)의 내용을 디지털화하고 보안 및 상호 작용 기능을 추가하여 모바일 환경에 최적화된 데이터 규격입니다.
단일 인스턴스 내에서 **여러 종류의 지류** (예: 주문서, 전표, 영수증, 번호표, 쿠폰, 티켓)를 지원하도록 기능이 대폭 확장되어 활용도가 크게 증가했습니다. 특히 **AES-GCM 암호화** 지원을 통해 보안 전송 및 저장이 가능합니다.

이 프로젝트는 이중 라이선스 모델을 채택하고 있습니다.

* **GPLv3**: 개인 및 비영리 목적의 사용에 적용됩니다. 이 라이선스에 따라 소스 코드를 사용하려면 파생된 작업물 역시 GPLv3로 공개해야 합니다.
* **상용 라이선스**: GPLv3의 의무를 따르지 않고자 하는 공공기관, 영리기업 등 단체는 별도의 상용 라이선스를 구매해야 합니다. 단, 비영리 목적이라도 전문적인 기술 지원이나 맞춤형 개발 등 협업을 원할 경우 상용 라이선스에 대해 문의할 수 있습니다. 상용 라이선스에 대한 문의는 [icitlabs@gmail.com]으로 연락 주시기 바랍니다.

---

## 🏗️ 스마트페이퍼 데이터 모델 및 리팩토링 (통합)

SmartPaper 데이터 모델은 `202506221515` 버전 코드부터 단일 용지 내에서 여러 종류의 지류를 효율적으로 지원하도록 **다단계 구조 및 통합 필드**로 크게 업데이트되었습니다.

### 데이터 모델 변경 및 필드 통합

1.  **새로운 SmartPaper 계층 구조 도입**:
    * **SmartPaper**는 기존 SmartPaper 구조의 일부와 **`SmartRecord`** 목록으로 구성됩니다.
    * **`SmartRecord`**는 배경 이미지, 외곽선 등의 속성을 가지며, **`SmartRecordLine`** 목록을 포함합니다.
    * 이 변경을 통해 단일 용지 내에서 **여러 독립적인 지류 항목 (Record)**을 관리할 수 있게 되었습니다.

2.  **이름 변경 및 필드 통합**:
    * 기존 `SmartPaperItem`은 **`SmartRecordLine`**으로 이름이 변경되었습니다.
    * 라인(Line) 레벨의 속성 필드들이 **통합**되었습니다. (예: `imageWidth`, `listWidth`, `buttonWidth` -> **`width`**)

```
SmartPaper (Version Code: 202506221515)
+-------------------------------------------------------------+
| SmartPaper Instance (Common Properties)                     |
| +---------------------------------------------------------+ |
| | SmartRecord 1 (Receipt/Ticket)                          | |
| | +-----------------------------------------------------+ | |
| | | SmartRecordLine 1 (Text/Image/Button)               | | |
| | +-----------------------------------------------------+ | |
| | | SmartRecordLine 2 (Text/Image/Button)               | | |
| | +-----------------------------------------------------+ | |
| +---------------------------------------------------------+ |
| | SmartRecord 2 (Coupon)                                  | |
| | +-----------------------------------------------------+ | |
| | | SmartRecordLine 1 (Text/Image/Button)               | | |
| | +-----------------------------------------------------+ | |
| +---------------------------------------------------------+ |
+-------------------------------------------------------------+
```

---

## ✨ 핵심 기능 (Features)

### 1. 보안 (Security) 기능 강화

* **AES-GCM 암호화**: 데이터의 **기밀성**과 **무결성**을 동시에 보장하는 **AES-256 GCM** 암호화 방식을 지원합니다.
* **결정적 키 파생 (Deterministic Key Derivation)**: 사용자가 설정한 PIN(`String`)을 기반으로 **SHA-256** 해시를 통해 암호화에 사용되는 강력한 256비트 **키(`Key`)**를 결정적으로 생성합니다.
* **안전한 난스(`Nonce`) 생성**: 암호화에 필수적인 12바이트(96비트)의 **고유 난수(Unique Nonce)**를 생성하여 GCM 모드의 보안을 극대화합니다.

### 2. URL 및 데이터 처리 유연성

SmartPaper는 URL을 통해 정적 데이터는 물론, 동적 상호작용 및 보안 기능까지 완벽하게 처리하는 정교하고 확장성 있는 시스템입니다.

| 파라미터 | 값 | 설명 |
| :--- | :--- | :--- |
| **`type=url`** | `url` | URL 파라미터에 포함된 **일반(평문) SmartPaper JSON URL**을 사용합니다. |
| **`type=surl`** | `url` | URL 파라미터에 포함된 **암호화된(AES-GCM) 데이터**와 `iv` (Nonce), `keyBits` 등 복호화에 필요한 파라미터를 전달받아 처리합니다. |
| **`type=paper`** | `url` | Base64로 인코딩된 **SmartPaper 객체 JSON 데이터**를 직접 디코딩하여 사용합니다. |
| **`autoRefresh`** | `ms` | 0보다 큰 값(ms) 지정 시, 해당 간격으로 데이터를 자동 새로고침하여 **실시간 갱신**을 지원합니다. |
| **`isPinSetting`** | `bool` | 핀(PIN) 설정이 필요한 보안 문서를 다룰 때 사용됩니다. |

---

## 📜 지원되는 콘텐츠 유형 (통합 필드 기준)

SmartRecordLine 레벨에서 지원되는 주요 콘텐츠 유형 및 설정입니다.

### 1. 공통 및 배경 설정

* **정렬 (`alignment`):** 섹션 내에서의 위치 정의 (예: `center`, `topRight` 등).
* **배경 이미지**: `bgImageSrc`, `bgImageOpacity`, `smartPaperImageType` (BoxFit 및 ImageRepeat 계열 지원).
* **테두리**: `outlineWidth` (SmartRecord 레벨)

### 2. 콘텐츠 유형 (`type` 속성 기준)

| Type ID | 유형 | 핵심 속성 (통합 필드) | 추가 속성 |
| :--- | :--- | :--- | :--- |
| 0 | **이미지** | `mediaSrc`, `width`, `height` | `alignment` |
| 1 | **텍스트** | `text`, `textSize`, `textColor`, `textStyle` | `textMaxLines`, `blankRatio` (패드 문자열용) |
| 4 | **구분선** | `dividerStyle` | `textSize` |
| 5 | **바코드** | `text` (데이터), `width`, `height` | `alignment` |
| 6 | **QR 코드** | `text` (데이터), `width`, `height` | `alignment` |
| 7 | **리스트** | `listItems` (SmartRecordLine 목록), `title`, `listType` | `textSize`, `textColor` (아이템 텍스트 설정) |
| 8 | **버튼** | `text`, `actionType`, `actionUrl` | `width`, `height`, `textSize`, `textColor` |
| 9 | **타이머** | `millis`, `actionType`, `actionUrl` | `timerType`, `text`, `textSize` |
| 10 | **비디오** | `mediaSrc`, `title`, `isLooping` | `width`, `height`, `titleSize`, `titleColor` |
| 11 | **오디오** | `mediaSrc`, `title`, `isLooping` | `titleSize`, `titleColor` |
| 12 | **알람 (지원 예정)** | `datetime` (yyyyMMddHHmmss), `title` | `titleSize`, `titleColor` |
| 13 | **문서 (지원 예정)** | `mediaSrc`, `title` | `titleSize`, `titleColor`, `width`, `height` |
| 14 | **URL** | `url`, `title` | `titleSize`, `titleColor` |
| 15 | **그룹 (지원 예정)** | `group` (SmartRecordLine 목록), `groupSpace` | `alignment` |

---

## ⌨️ 사용 방법 (C# 예시)

**Helper 클래스 (`SmartPaperHelper`) 및 Manager 클래스 (`SmartPaperManager`)**를 사용하여 SmartPaper 객체를 쉽게 구성하고 암호화할 수 있습니다.

### 1. 데이터 구성

```csharp
// 1. SmartPaper와 SmartRecord 인스턴스 생성
SmartPaper smartPaper = new();
SmartRecord smartRecord = new();
smartPaper.smartRecordList.Add(smartRecord); // 단일 용지 내에 여러 레코드 추가 가능

// 2. 레코드에 배경 이미지 및 외곽선 설정
smartRecord.bgImageSrc = "[https://image.example.com/background.png](https://image.example.com/background.png)";
smartRecord.bgImageOpacity = 0.2;
smartRecord.smartPaperImageType = SmartPaperImageType.cover;
smartRecord.outlineWidth = 2.0;

// 3. Helper를 사용한 SmartRecordLine 추가

// - 이미지 라인 추가
smartRecord.items.Add(SmartPaperHelper.Image("[https://image.example.com/logo.png](https://image.example.com/logo.png)", 360, 240, SmartRecordLineAlignment.center));

// - 구분선 라인 추가
smartRecord.items.Add(SmartPaperHelper.Divider(SmartRecordLineDividerStyle.equal, textSize: 15.0));

// - 텍스트 라인 추가
smartRecord.items.Add(SmartPaperHelper.Text(
    text: "주문 내역",
    textStyle: SmartRecordLineTextStyle.bold,
    textSize: 18.0,
    alignment: SmartRecordLineAlignment.center
));

// - 패드 문자열 (Pad String) 라인 추가
PadString padString1 = new PadString(text: "대기 번호 ", padFlex: 2, alignment: SmartRecordLineAlignment.centerRight);
PadString padString2 = new PadString(text: "123", padFlex: 1, alignment: SmartRecordLineAlignment.centerLeft);
List<PadString> padStringList = new List<PadString> { padString1, padString2 };

smartRecord.items.Add(SmartPaperHelper.MakePadStringLine(
    data: padStringList,
    textStyle: SmartRecordLineTextStyle.normal,
    textSize: 21.0
));


// 1. SmartPaper 객체를 JSON 문자열로 변환
string jsonData = SmartPaper.toJson(smartPaper);

// 2. PIN을 기반으로 보안 키 생성
string pin = "abc123#@$"; // (사용자 입력)
byte[] keyBytes = SmartPaperManager.GenerateDeterministicKeyFromPin(pin);
byte[] nonceBytes = SmartPaperManager.GenerateUniqueNonce();

// 3. 일반(평문) URL 생성
string paperUrl = "[https://paper.example.com/order_receipt_001.json](https://paper.example.com/order_receipt_001.json)";
string? url = SmartPaperManager.GenerateUrl(paperUrl, isAutoSave: true); // 자동 저장 기능 포함

// 4. 암호화 후 보안 URL 생성 (surl 타입)
string encryptedDataUrl = "[https://data.example.com/encrypted_order_001.paper](https://data.example.com/encrypted_order_001.paper)";
string? surl = SmartPaperManager.EncryptAndGenerateUrl(
    encryptedDataUrl,
    keyBytes,
    nonceBytes,
    isAutoSave: false
);
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
