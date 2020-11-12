(function () {
    const alertElement = document.getElementById("success-alert");
    const formElement = document.forms[0];

    const addNewItem = async () => {
        // 1. read data from the form
        const requestData = new FormData(formElement);
        // 2. call the application server using fetch method
        const response = await fetch("api/company",
            {
                body: requestData,
                method: "post"
            });

        //const responseJson = await response.json();

        if (response.status === 200) {
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