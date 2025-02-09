class LocalStorageHandler {
    
    setItem(key, value) {
        localStorage.setItem(key, JSON.stringify(value));
    }
    
    getItem(key) {
        const storedValue = localStorage.getItem(key)
        return storedValue ? JSON.parse(storedValue) : null;
    }

    clearLocalStorage() {
        localStorage.clear();
    }
}
