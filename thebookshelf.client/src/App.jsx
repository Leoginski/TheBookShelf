import { useEffect, useState } from 'react';
import './App.css';

function App() {
    const [books, setbooks] = useState();

    useEffect(() => {
        populateBookData();
    }, []);

    const contents = books === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>

        :
        <div>
            <label> Search Type:
                <select id="searchType">
                    <option value="author">Author</option>
                    <option value="isbn">ISBN</option>
                    <option value="love">Love</option>
                </select>
            </label>

            <br />

            <label> Search Value:
                <input id="searchValue" type="text" />
            </label>

            <br />

            <button onClick={populateBookData}>Search</button>

            <table className="table table-striped" aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Title</th>
                        {/*<th>Publisher</th>*/}
                        <th>Author</th>
                        <th>Type</th>
                        <th>ISBN</th>
                        <th>Category</th>
                        <th>AvailableCopies</th>
                    </tr>
                </thead>
                <tbody>
                    {books.map(book =>
                        <tr key={book.id}>
                            <td>{book.title}</td>
                            {/*<td>{book.Publisher}</td>*/}
                            <td>{book.lastName} {book.firstName}</td>
                            <td>{book.type}</td>
                            <td>{book.isbn}</td>
                            <td>{book.category}</td>
                            <td>{book.copiesInUse}/{book.totalCopies}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>;

    return (
        <div>
            <h1 id="tabelLabel">The Book Shelf</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );

    async function populateBookData() {
        let url = 'api/v1/books';

        const searchType = document.getElementById('searchType');
        const searchValue = document.getElementById('searchValue');

        if (searchType && searchValue && searchType.value && searchValue.value) {
            url += `?${searchType.value}=${searchValue.value}`
        }

        const response = await fetch(url);

        const data = await response.json();
        setbooks(data);
    }
}

export default App;