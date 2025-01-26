# Expense Tracker App

## Project Overview
This project aims to create a simple and efficient expense tracker application using Vue for the frontend, a .NET API for the backend, and PostgreSQL as the database. The app will cater to individual users as well as households, allowing multiple users to manage expenses collaboratively. While starting with basic functionality, the project will evolve to include analytics, receipt uploads, and AI-based receipt scanning for automatic product recognition and categorization.

## Key Features

### Phase 1: Core Expense Tracking
1. **User and Household Management**:
   - Users can register, log in, and manage their accounts.
   - Households can have multiple users, with shared expense tracking.

2. **Expense Logging**:
   - Add expenses with details:
     - Amount
     - Category (e.g., groceries, utilities, entertainment)
     - Date
     - Description
     - Optional tags
   - Track recurring expenses (frequency: daily, weekly, monthly, yearly).

3. **Basic Expense Overview**:
   - Display a list of expenses.
   - Filter expenses by date, category, or tag.
   - Summarize expenses by category and time period.

### Phase 2: Analytics and Receipt Uploads
1. **Expense Analytics**:
   - Visualize spending trends over time.
   - Breakdown by category and household.
   - Compare current spending to historical averages.

2. **Receipt Management**:
   - Upload and attach receipts to expenses.
   - View and download uploaded receipts.

### Phase 3: AI and Advanced Analytics
1. **AI Receipt Scanning**:
   - Use AI to scan uploaded receipts and extract product details.
   - Automatically categorize expenses based on receipt data.

2. **Advanced Expense Insights**:
   - Identify spending patterns.
   - Offer suggestions for budget optimization.
   - Provide alerts for unusual spending.

## Technology Stack
1. **Frontend**:
   - Vue.js (TypeScript)
   - Vite
   - Tailwind CSS for styling
2. **Backend**:
   - .NET 8 API
   - Authentication using JWT
3. **Database**:
   - PostgreSQL
4. **Other Tools**:
   - Docker for containerization
   - AI services (e.g., Azure Custom Vision or OpenAI models) for receipt scanning

## Milestones

### Milestone 1: Core Functionality (MVP)
- [ ] User authentication (login, registration, JWT-based auth).
- [ ] Household management (add/remove users to/from a household).
- [ ] Basic expense tracking (amount, category, date, description, tags).
- [ ] Display expenses and apply basic filters.

### Milestone 2: Enhanced User Experience
- [ ] Add support for recurring expenses.
- [ ] Implement receipt upload functionality.
- [ ] Create basic analytics (spending trends, category breakdown).

### Milestone 3: Advanced Features
- [ ] Integrate AI for receipt scanning and product recognition.
- [ ] Enhance analytics with advanced visualizations and spending pattern insights.
- [ ] Add budgeting tools and alerts for spending anomalies.

### Milestone 4: Polishing and Deployment
- [ ] Optimize UI for responsiveness.
- [ ] Conduct user testing and gather feedback.
- [ ] Deploy to production (using Docker containers).

## Future Enhancements
- Multi-language support.
- Integration with financial APIs for automatic transaction imports.
- Export reports to PDF or Excel.
- Budget planning and goals.

## Contribution Guidelines
1. Fork the repository and create a feature branch.
2. Submit pull requests with clear descriptions of the changes made.
3. Write unit and integration tests for any new functionality.
4. Follow coding guidelines and ensure code is well-documented.

## License
This project will be licensed under the MIT License.

---

By focusing on simplicity and scalability, this project aims to grow into a powerful tool for managing personal and household finances while incorporating modern technologies like AI for added value.
