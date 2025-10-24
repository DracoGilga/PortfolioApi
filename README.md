# DracoGilga PortfolioApi

**DracoGilga PortfolioApi** is a system developed in **C# (.NET 8)** that implements a **GraphQL server** to centralize personal and professional information.  
It allows users to **query my favorite GitHub repositories**, **view my CV**, and **send contact messages via email**.

The project is hosted on **Azure App Service**, and is consumed by the website [**dracogilga.com**](https://dracogilga.com)

---

## Main Features

- **Favorite repositories query:** Retrieves data directly from the GitHub API.  
- **CV query:** Accesses my professional profile through GraphQL.  
- **Contact system:** Allows sending emails directly from the API.  
- **Azure App Service deployment:** Ensures availability, scalability, and security.  
- **GraphQL Server:** Built on .NET 8, providing a clean and flexible schema.

---

## Technologies Used

| Technology | Description |
|-------------|-------------|
| **C# / .NET 8** | Main backend framework |
| **GraphQL** | Flexible data query API |
| **GitHub API** | Source for favorite repositories |
| **SMTP** | Email delivery system |
| **Azure App Service** | Cloud hosting and deployment |

---

## Local Setup

### 1️⃣ Clone the repository
```bash
git clone https://github.com/DracoGilga/PortfolioApi.git
cd PortfolioApi
```

### 2️⃣ Configure environment variables or `appsettings.json`
Make sure to include your GitHub and SMTP credentials.
```json
{
  "GitHub": {
    "User": "",
    "Token": ""
  },
  "EmailSettings": {
        "From": "Email",
        "FromName": "Contact Me",
        "Password": "Key",
        "Host": "",
        "Port": 587,
        "EnableSsl": true,
        "To": ""
    }
}
```

---

## Deployment

This project is deployed on **Azure App Service** with continuous integration from GitHub.  
Every commit to the main branch triggers an automatic deployment to production.

🔗 **Website:** [dracogilga.com](https://dracogilga.com)

---

## Author

**Cesar**  
Software Engineering passionate about Software Architecture, Full Stack Development, and building scalable, high-performance solutions.  
Contact: [cesar96707@gmail.com](mailto:cesar96707@gmail.com)

