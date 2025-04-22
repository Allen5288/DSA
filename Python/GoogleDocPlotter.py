#!/usr/bin/env python3
"""
Fetches a published Google Doc containing a table of Unicode characters with x,y coordinates,
reconstructs a 2D grid, and prints it in fixed-width form.

Usage:
    python google_doc_unicode_grid.py <GOOGLE_DOC_PUB_URL>

Dependencies:
    pip install requests beautifulsoup4

Example:
    python google_doc_unicode_grid.py \
      "https://docs.google.com/document/d/e/2PACX-1vQGUck9HIFCyezsrBSnmENk5ieJuYwpt7YHYEzeNJkIb9OSDdx-ov2nRNReKQyey-cwJOoEKUhLmN9z/pub"
"""
import sys
import requests
from bs4 import BeautifulSoup


def fetch_entries(url):
    """
    Fetch the HTML from the published Google Doc URL and parse out entries of the form:
    a table with columns: x-coordinate, Character, y-coordinate.
    Returns a list of tuples (x: int, y: int, char: str).
    """
    resp = requests.get(url)
    resp.raise_for_status()

    soup = BeautifulSoup(resp.text, 'html.parser')
    table = soup.find('table')
    if not table:
        raise ValueError("Could not find table in the document. Is the URL correct and published?")

    entries = []
    # assume first row is header
    rows = table.find_all('tr')
    for row in rows[1:]:
        cells = row.find_all(['td', 'th'])
        if len(cells) < 3:
            continue
        # Extract texts and normalize whitespace
        x_text = cells[0].get_text().strip().replace('\u00A0', ' ')
        char_text = cells[1].get_text().strip().replace('\u00A0', ' ')
        y_text = cells[2].get_text().strip().replace('\u00A0', ' ')
        # Validate and convert
        if not x_text.isdigit() or not y_text.isdigit():
            continue
        if len(char_text) != 1:
            # skip invalid
            continue
        x = int(x_text)
        y = int(y_text)
        entries.append((x, y, char_text))
    return entries


def build_grid(entries):
    """
    Given a list of (x, y, char), build a 2D list (grid) of characters,
    filling missing positions with space.
    Coordinates assume x increases to the right, y increases downward, and
    the minimum coordinate is 0.
    """
    if not entries:
        raise ValueError("No entries found in the document table.\n"
                         "Verify that the document contains the expected table.")

    max_x = max(x for x, _, _ in entries)
    max_y = max(y for _, y, _ in entries)
    # initialize grid of spaces
    grid = [[' ' for _ in range(max_x + 1)] for _ in range(max_y + 1)]
    for x, y, char in entries:
        grid[y][x] = char
    return grid


def print_grid(grid):
    """
    Print each row of the grid on its own line, joining characters without delimiter.
    """
    for row in grid:
        print(''.join(row))


def main():
    if len(sys.argv) != 2:
        print(f"Usage: {sys.argv[0]} <GOOGLE_DOC_PUB_URL>")
        sys.exit(1)

    url = sys.argv[1]
    try:
        entries = fetch_entries(url)
        grid = build_grid(entries)
        print_grid(grid)
    except Exception as e:
        print(f"Error: {e}")
        sys.exit(1)


if __name__ == '__main__':
    main()
