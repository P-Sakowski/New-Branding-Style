(function () {
    const alertElement = document.getElementById("success-alert");
    const formElement = document.forms[0];

    const addNewItem = async () => {
        // 1. read data from the form
        const requestData = new FormData(formElement);
        // 2. call the application server using fetch method
        const response = await fetch("api/Item",
            {
                body: requestData,
                method: "post"
            });
        console.log(response);

        const responseJson = await response.json();

        if (responseJson.success) {
            alertElement.style.display = 'block';
        }
    };

    window.addEventListener("load", () => {
        formElement.addEventListener("submit", event => {
            event.preventDefault();
            addNewItem().then(() => console.log("added successfully"));
        });
    });
})();