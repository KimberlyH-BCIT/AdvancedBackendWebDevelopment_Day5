# WebSecurityDemo – Starter Application

This repository contains the **starter code** for the WebSecurityDemo security exercise used in the BCIT SSD program.

The application is intentionally **insecure** and is designed to be hardened by students as part of a graded exercise.

---

## 🔍 Application Overview

This ASP.NET Core MVC application already includes:

- ASP.NET Core MVC
- ASP.NET Core Identity
- Entity Framework Core with SQLite
- Role and User Role management
- Customer, Role, and UserRole delete functionality (intentionally insecure)

---

## ❗ Known Security Issues (Intentional)

The starter application has the following security vulnerabilities:

- **CSRF vulnerabilities**
  - Customer, Role, and UserRole delete actions use **GET** requests.
  - No Anti-Forgery Tokens are implemented.

- **No brute-force protection**
  - Login attempts are not limited.
  - Account lockout is not configured.

- **Source control**
  - This repository is provided as a starting point only.
  - Students must publish their secured version to their **own GitHub account**.

---

## ✅ Student Task Summary

You are required to:

1. Secure delete operations using:
   - POST requests
   - Anti-Forgery Tokens

2. Implement Identity lockout protection:
   - Lock out accounts after **5 failed login attempts**
   - Lockout duration of **5 minutes** (for testing purposes)

3. Push your secured version of the application to **your own GitHub repository**

4. Submit:
   - A link to your GitHub repository
   - A short written summary describing:
     - Which endpoints were secured
     - How lockout was configured

---

## 🛠 Getting Started

Clone this repository **directly in Visual Studio**.

Refer to:
> **“Visual Studio – Cloning from GitHub.pdf”**  
located on the Learning Hub for step-by-step instructions.

---

## ⚠️ Important Notes

- Do **not** submit a zip file.
- Do **not** submit a fork of this repository.
- Visual styling is not graded — focus on **security implementation**.

---

© BCIT SSD – Web Security Exercise
