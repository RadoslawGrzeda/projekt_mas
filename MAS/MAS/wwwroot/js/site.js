// helper dla alertów
function showAlert(type, msg) {
    const wrap = document.getElementById('alerts');
    if (!wrap) return;
    wrap.innerHTML = `<div class="alert ${type}">${msg}</div>`;
    setTimeout(() => (wrap.innerHTML = ''), 4000);
}

// zakładki
document.addEventListener('DOMContentLoaded', () => {
    // aktywuj dzisiejszą/ jutrzejszą datę
    const start = document.getElementById('startDate');
    if (start) {
        const d = new Date();
        d.setDate(d.getDate() + 1);
        start.value = d.toISOString().slice(0, 10);
    }

    // przełączanie zakładek
    const tabs = document.getElementById('tabs');
    if (tabs) {
        tabs.addEventListener('click', (e) => {
            const btn = e.target.closest('button[data-tab]');
            if (!btn) return;
            const name = btn.dataset.tab;

            // aktywuj przycisk
            tabs.querySelectorAll('.menu-item').forEach(b => b.classList.remove('active'));
            btn.classList.add('active');

            // aktywuj panel
            document.querySelectorAll('.tab-pane').forEach(p => p.classList.remove('active'));
            document.getElementById(`tab-${name}`).classList.add('active');
        });
    }

    // filtr aut -> GET /api/person/showAvailableCars
    const form = document.getElementById('filter-cars');
    const list = document.getElementById('cars-list');
    if (form && list) {
        form.addEventListener('submit', async (e) => {
            e.preventDefault();
            const startDate = document.getElementById('startDate').value;
            const days = document.getElementById('days').value;

            if (!startDate || !days) return;

            list.innerHTML = '<p class="muted">Ładowanie…</p>';
            try {
                const res = await fetch(`/api/person/showAvailableCars?startDate=${startDate}&numberOfDays=${days}`);
                if (!res.ok) throw new Error('Błąd API');
                const cars = await res.json();

                if (!Array.isArray(cars) || cars.length === 0) {
                    list.innerHTML = '<p class="muted">Brak aut w podanym terminie.</p>';
                    return;
                }

                list.innerHTML = '';
                cars.forEach(c => {
                    // API zwraca krotki: (id, brand, model, dailyRate)
                    const [id, brand, model, dailyRate] = [c.id, c.brand, c.model, c.dailyRate];
                    const card = document.createElement('div');
                    card.className = 'card';
                    card.innerHTML = `
            <div class="car-name">${brand} ${model}</div>
            <div class="car-meta">
              <div>Koszt: ${Number(dailyRate).toFixed(0)} zł/dzień</div>
            </div>
            <button class="btn danger" data-reserve='${JSON.stringify({ id, startDate, days })}'>
              Rezerwuj
            </button>`;
                    list.appendChild(card);
                });
            } catch (err) {
                list.innerHTML = '<p class="muted">Nie udało się pobrać listy aut.</p>';
            }
        });

        // obsługa kliknięcia „Rezerwuj” -> POST /api/person/make_reservation
        list.addEventListener('click', async (e) => {
            const btn = e.target.closest('button[data-reserve]');
            if (!btn) return;
            const { id, startDate, days } = JSON.parse(btn.dataset.reserve);
            try {
                const body = new URLSearchParams({
                    carId: id,
                    startDate: startDate,
                    numberOfDays: days
                });
                const res = await fetch('/api/person/make_reservation', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                    body
                });
                if (!res.ok) {
                    const txt = await res.text();
                    showAlert('error', txt || 'Nie udało się utworzyć rezerwacji.');
                    return;
                }
                showAlert('success', `Zarezerwowano auto (ID ${id}) od ${startDate} na ${days} dni.`);
            } catch (err) {
                showAlert('error', 'Błąd sieci przy rezerwacji.');
            }
        });
    }

    // Ping do /api/person/test (w zakładce Rezerwacje)
    const pingBtn = document.getElementById('ping-api');
    const pingOut = document.getElementById('ping-out');
    if (pingBtn && pingOut) {
        pingBtn.addEventListener('click', async () => {
            try {
                const r = await fetch('/api/person/test');
                pingOut.textContent = await r.text();
            } catch {
                pingOut.textContent = 'Błąd połączenia';
            }
        });
    }
});
