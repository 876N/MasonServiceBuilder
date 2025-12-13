# Mason Service Builder

Create your own Windows service using **Mason Service Builder**
This tool allows you to convert a regular executable into a **native Windows Service**, with full control over its **file format**, **icon**, and **assembly metadata**

Developed by **ABOLHB** — *MasonGroup*

---

![Tool Preview](https://i.ibb.co/0ywZCP0T/2025-12-12-065843.png)

---

The tool features a **clean, focused, and purpose-built design**, created **exclusively for service construction**
Any usage outside this scope is the sole responsibility of the user

---

## Supported Output Formats

The builder allows exporting the final service binary in multiple executable formats:

* `.exe`
* `.scr`
* `.com`
* `.pif`
* `.bat`
* `.cmd`

The output format is selected dynamically through:

```cs
guna2ComboBox1_SelectedIndexChanged
```

This does not alter the internal logic of the service; it only affects how the file is represented and registered by Windows

---

## Builder Architecture (MasonForm.cs)

The builder is responsible for **preparing, configuring, and compiling** the final service binary

### Core Responsibilities

* Accepting an input executable via **Drag & Drop** or file picker
* Converting the executable into position-independent shellcode using **Donut**
* Injecting the generated shellcode into a predefined **service stub**
* Compiling the final service using `CSharpCodeProvider`

---

### Shellcode Generation

The builder invokes `donut.dll` to transform the selected executable into raw shellcode:

* The output is written to a temporary `.bin` file
* The shellcode bytes are read and converted into a hexadecimal string
* This string is injected directly into the stub source code at compile time

This ensures the final service contains **no external payload files**.

---

### Assembly Metadata Cloning

When **AssemblyCheckBox1** is enabled, the builder extracts metadata from any selected `.exe` file using:

* `FileVersionInfo`

The following attributes are cloned and embedded into the final service:

* Title
* Description
* Product
* Company
* Copyright
* Trademark

If disabled, all assembly attributes are **fully stripped** from the stub source before compilation.

---

### Icon Binding

When **IconCheckBox1** is enabled:

* Any `.ico` file can be selected
* The icon is injected at compile time using `/win32icon`
* The selected icon is previewed inside the UI

This affects both **Explorer appearance** and **Service Manager visuals**.

---

### Compilation

The final service is compiled with:

* Embedded application manifest
* Administrator execution level
* Optimized WinExe target
* Optional icon and assembly metadata

All compilation is performed **in-memory** using source generation.

---

## Stub Architecture (Stub.cs)

The stub is the **runtime core** of the generated service.
It is designed to be **self-contained**, **single-instance**, and **persistent**.

---

### Service Initialization

* The service name is generated dynamically from the executable filename
* Invalid characters are stripped
* Windows service naming rules are strictly enforced

This guarantees compatibility with `sc.exe` and the Service Control Manager.

---

### Self-Deployment Logic

On first execution:

* The binary copies itself into the Windows **System32** directory
* The copied file is marked as **Hidden** and **System**
* Execution continues only from the system directory

```cs
File.SetAttributes(targetPath, FileAttributes.Hidden | FileAttributes.System);
```

This prevents casual discovery by standard users.

---

## Process Appearance

This is how the service appears in the process list:

![Service Preview](https://i.ibb.co/Y70bNZyV/Mason-Service.png)

---

The service is created using the **same name as the executable**:

![Service Created Preview](https://i.ibb.co/ZjvNWsf/image.png)

---

The binary is stored inside the **system directory**:

![System Preview](https://i.ibb.co/cSnzGvDb/image.png)

---

## Execution Model

### Service vs Installer Mode

* When executed interactively, the binary installs itself as a service
* When started with `/service`, it runs under `ServiceBase`

Service installation is performed using native `sc.exe` commands:

* create
* description
* failure policy
* auto-start configuration

---

### Single Instance Enforcement

A **global mutex** ensures that only one instance of the service can run system-wide.
If a second instance is detected, it terminates immediately.

---

### Shellcode Execution

* Shellcode is allocated using `VirtualAlloc`
* Memory is marked as executable
* Execution is performed via `CreateThread`
* The service continuously monitors the thread state
* If the thread exits unexpectedly, it is relaunched (only by the main instance)

This provides **controlled persistence** without spawning additional processes.

---

### Error Handling & Stability

* Windows Error Reporting (WER) is fully disabled
* Thread state is monitored using `GetExitCodeThread`
* Memory and thread handles are cleaned safely on shutdown

---

## File Hiding Feature

The service binary is hidden from standard file browsing:

![Hide Preview](https://i.ibb.co/twXDJGCW/image.png)

When manually searching for the file path, the average user will not notice it due to system-level attributes.

---

## Disclaimer

> *We hereby declare that we disclaim any liability for any improper or unintended use of this software.
> This project is provided for technical and educational purposes only.
> By using this software, you assume full responsibility for its usage.*

---

**Copyright © Freemasonry 2025**
