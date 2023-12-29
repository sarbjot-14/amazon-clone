Data Models:
Product: 
- id
- name
- price
- description
- rating
- number of ratings
- imageurl
- quantity
- category
- size
- discount
- company

Order:
- id
- productId
- customerId
- total
- quantity
- address


User Requirements:
- Search 
- Add to cart
  - If not signed in then saves locally
    - Asked to sign in when click on cart
  - If logged in then saves to account
  - Delete
  - Change quantity (Add limit of how many are remaining)
- login/signup


Views:
- landing page
  - Navbar
    - logo, search, account, cart
  - Cards:  Top Deals, Toys under $25, Beauty steals under 25, Deals on Shoes
  - infinite carsoul: Popular electronics
- Sidebar:
  - Shop By Department:
    - Electronics
    - Computers
    - Smart Home
    - Fashion
    - .....
  - Programs & Features
    - ...
  - Help & Settings
    - Your Account
- Search Page
  - Customer Review
  - Brands
  - Price Range
  - Availability
- Product page
- Cart Page
- Checkout Page
  - address
  - payment method
  - Review items and shipping
  - Total with taxes and shipping based on location
  - Arrival date
- 
