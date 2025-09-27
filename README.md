# SmartPaper 🛡️

This repository provides the SmartPaper data model and related logic.

Protect nature, and nature will protect you! 🌳</br>
Be free from all bisphenols... 🚫

**SmartPaper** is a data standard optimized for mobile environments that digitizes the content of paper documents (receipts, tickets, etc.) and adds security and interactivity features.
Its functionality has been significantly expanded to support **multiple types of paper** (e.g., order forms, vouchers, receipts, number tags, coupons, tickets) within a single instance, significantly increasing its usability. Support for **AES-GCM encryption** also enables secure transmission and storage.

This project adopts a dual licensing model.

* **GPLv3**: Applies to personal, public, and non-profit use. Under this license, any derived works must also be released under GPLv3.
* **Commercial License**: For-profit companies that do not wish to comply with the obligations of the GPLv3 must purchase a separate commercial license. For inquiries regarding commercial licensing, please contact [icitlabs@gmail.com].

---

## 🏗️ Smartpaper Data Model and Refactoring (Integration)

The SmartPaper data model has been significantly updated with **multi-level structures and unified fields** to efficiently support multiple paper types within a single instance, starting with version code `202506221515`.

### Change data model and integrate fields

1.  **Introducing a new SmartPaper hierarchy**:
    * A **SmartPaper** consists of a portion of the existing SmartPaper structure and a **`SmartRecord`** list.
    * A **`SmartRecord`** has properties such as a background image and outline, and contains a **`SmartRecordLine`** list.
    * This change allows for managing **multiple independent paper items (Records)** within a single paper.

2.  **Rename and field consolidation**:
    * The existing `SmartPaperItem` has been renamed to **`SmartRecordLine`**.
    * Line-level properties have been **consolidated** (e.g., `imageWidth`, `listWidth`, `buttonWidth` -> **`width`**).

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

## ✨ Features

### 1. Enhanced Security

* **AES-GCM Encryption**: Supports **AES-256 GCM** encryption, ensuring both data **confidentiality** and **integrity**.
* **Deterministic Key Derivation**: Deterministically generates a strong 256-bit **key** used for encryption through **SHA-256** hashing based on the user-set PIN (`String`).
* **Secure Nonce Generation**: Maximizes the security of GCM mode by generating a 12-byte (96-bit) **unique nonce** essential for encryption.

### 2. Flexibility in URL and data processing

SmartPaper is a sophisticated and scalable system that handles static data, dynamic interactions, and security features through URLs.

| Parameter | Value | Description |
| :--- | :--- | :--- |
| **`type=url`** | `url` | Uses the **plaintext SmartPaper JSON URL** contained in the URL parameter. |
| **`type=surl`** | `url` | Receives and processes **encrypted (AES-GCM) data** along with necessary decryption parameters (e.g., iv for Nonce, keyBits). |
| **`type=paper`** | `url` | Directly decodes and uses **SmartPaper object JSON data** encoded in Base64. |
| **`autoRefresh`** | `ms` | If a value greater than 0 (ms) is specified, data is automatically refreshed at that interval to support **real-time updates**. |
| **`isPinSetting`** | `bool` | Used when handling secure documents that require PIN settings. |

---

## 📜 Supported content types (based on integration fields)

The main content types and settings supported at the SmartRecordLine level are as follows:

### 1. Common and Background Settings

* **Alignment`:** Defines the position within the section (e.g., `center`, `topRight`, etc.).
* **Background Image**: `bgImageSrc`, `bgImageOpacity`, `smartPaperImageType` (supports BoxFit and ImageRepeat families).
* **Border**: `outlineWidth` (SmartRecord level)

### 2. Content Type (based on `type` property)

| Type ID | Type | Core Properties (Unified Fields) | Additional Properties |
| :--- | :--- | :--- | :--- |
| 0 | **Image** | `mediaSrc`, `width`, `height` | `alignment` |
| 1 | **Text** | `text`, `textSize`, `textColor`, `textStyle` | `textMaxLines`, `blankRatio` (for padded strings) |
| 4 | **Divider** | `dividerStyle` | `textSize` |
| 5 | **Barcode** | `text` (data), `width`, `height` | `alignment` |
| 6 | **QR Code** | `text` (data), `width`, `height` | `alignment` |
| 7 | **List** | `listItems` (SmartRecordLine list), `title`, `listType` | `textSize`, `textColor` (set item text) |
| 8 | **Button** | `text`, `actionType`, `actionUrl` | `width`, `height`, `textSize`, `textColor` |
| 9 | **Timer** | `millis`, `actionType`, `actionUrl` | `timerType`, `text`, `textSize` |
| 10 | **Video** | `mediaSrc`, `title`, `isLooping` | `width`, `height`, `titleSize`, `titleColor` |
| 11 | **Audio** | `mediaSrc`, `title`, `isLooping` | `titleSize`, `titleColor` |
| 12 | **Alarm (Planned)** | `datetime` (yyyyMMddHHmmss), `title` | `titleSize`, `titleColor` |
| 13 | **Document (Planned)** | `mediaSrc`, `title` | `titleSize`, `titleColor`, `width`, `height` |
| 14 | **URL** | `url`, `title` | `titleSize`, `titleColor` |
| 15 | **Group (Planned)** | `group` (SmartRecordLine list), `groupSpace` | `alignment` |

---

## ⌨️ How to Use (C# Example)

You can easily configure and encrypt SmartPaper objects using the **Helper class (`SmartPaperHelper`) and the Manager class (`SmartPaperManager`).

### 1. Data Configuration

```csharp
// 1. Create SmartPaper and SmartRecord instances
SmartPaper smartPaper = new();
SmartRecord smartRecord = new();
smartPaper.smartRecordList.Add(smartRecord); // Add multiple records to a single paper.

// 2. Set a background image and outline for the record
smartRecord.bgImageSrc = "[https://image.example.com/background.png](https://image.example.com/background.png)";
smartRecord.bgImageOpacity = 0.2;
smartRecord.smartPaperImageType = SmartPaperImageType.cover;
smartRecord.outlineWidth = 2.0;

// 3. Adding a SmartRecordLine using a Helper

// - Add an image line
smartRecord.items.Add(SmartPaperHelper.Image("[https://image.example.com/logo.png](https://image.example.com/logo.png)", 360, 240, SmartRecordLineAlignment.center));

// - Add a divider line
smartRecord.items.Add(SmartPaperHelper.Divider(SmartRecordLineDividerStyle.equal, textSize: 15.0));

// - Add a text line
smartRecord.items.Add(SmartPaperHelper.Text(
text: "Order History",
textStyle: SmartRecordLineTextStyle.bold,
textSize: 18.0,
alignment: SmartRecordLineAlignment.center
));

// - Add Pad String line
PadString padString1 = new PadString(text: "WaitNumber ", padFlex: 2, alignment: SmartRecordLineAlignment.centerRight);
PadString padString2 = new PadString(text: "123", padFlex: 1, alignment: SmartRecordLineAlignment.centerLeft);
List<PadString> padStringList = new List<PadString> { padString1, padString2 };

smartRecord.items.Add(SmartPaperHelper.MakePadStringLine( 
data:padStringList, 
textStyle: SmartRecordLineTextStyle.normal, 
textSize: 21.0
));


// 1. Convert SmartPaper object to JSON string
string jsonData = SmartPaper.toJson(smartPaper);

// 2. Generate a security key based on a PIN
string pin = "abc123#@$"; // The PIN is the value entered by the user.
byte[] keyBytes = SmartPaperManager.GenerateDeterministicKeyFromPin(pin);
byte[] nonceBytes = SmartPaperManager.GenerateUniqueNonce();

// 3. Generate a plaintext URL
string paperUrl = "[https://paper.example.com/order_receipt_001.json](https://paper.example.com/order_receipt_001.json)";
string? url = SmartPaperManager.GenerateUrl(paperUrl, isAutoSave: true); // Includes auto-save functionality.

// 4. Generate a secure URL after encryption (surl type)
string encryptedDataUrl = "[https://data.example.com/encrypted_order_001.paper](https://data.example.com/encrypted_order_001.paper)";
string? surl = SmartPaperManager.EncryptAndGenerateUrl(
encryptedDataUrl,
keyBytes,
nonceBytes,
isAutoSave: false
);
```

## Test Viewer

You can test the smartpaper you created.

<a href="https://www.publicplatform.co.kr/smartpaper/" target="_blank">
  🔗 Open SmartPaper Viewer
</a>

## Samples

* Real-time generation

> Link to [Movie & Parking Ticket](https://app.publicplatform.co.kr/?/smart_paper?type=paper&paper=sample&vendor=theater&savable=true)

> Link to [Waiting Number Ticket](https://app.publicplatform.co.kr/?/smart_paper?type=paper&paper=sample&vendor=bank_waiting_number&savable=true)

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
