
## What are the potential drawbacks of using sequential integer IDs for short URLs in terms of security and privacy?

Main drawbacks of sequential integer IDs for short URLs (security and privacy):
•	Easy enumeration and scraping
•	Predictable IDs let attackers crawl /1, /2, … to harvest every link, including “unlisted” ones.
•	Leakage of business and usage metrics

•	Increase shortURL length

Bottom line: Using the DB Id in the URL is simple but sacrifices opacity and makes enumeration and data leakage easy. An opaque, 
high-entropy short code (or an ID-derived, HMAC-signed/encoded token) provides much better security and privacy with minimal added complexity.

