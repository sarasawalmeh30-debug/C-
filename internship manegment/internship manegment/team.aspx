<!DOCTYPE html>
<html lang="ar" dir="rtl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>PSUT IT Team - UIMS</title>
    <style>
        :root {
            --psut-navy: #001f3f;
            --psut-blue: #0b3c5d;
            --psut-gold: #d4af37;
            --beige-bg: #f5f0eb;
        }

        * {
            box-sizing: border-box;
            margin: 0;
            padding: 0;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }

        body {
            background-color: var(--beige-bg);
            height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
            overflow: hidden;
        }

        /* حاوية الرف الرئيسية */
        .stage {
            width: 90vw;
            max-width: 1200px;
            height: 80vh;
            display: flex;
            flex-direction: column;
            justify-content: flex-end;
            align-items: center;
            position: relative;
        }

        /* رف الكتب الخشبي */
        .bookshelf {
            width: 100%;
            display: flex;
            justify-content: center;
            align-items: flex-end;
            gap: 20px;
            padding-bottom: 20px;
            border-bottom: 25px solid #5c3a21;
            box-shadow: 0 15px 25px rgba(0,0,0,0.3);
            position: relative;
        }

        /* تصميم الكتاب على الرف (مغلق) */
        .book-spine {
            width: 75px;
            height: 320px;
            background: linear-gradient(90deg, #001226 0%, var(--psut-navy) 40%, var(--psut-blue) 70%, #001226 100%);
            border-radius: 8px 8px 3px 3px;
            border: 2px solid var(--psut-gold);
            cursor: pointer;
            box-shadow: 5px 10px 15px rgba(0, 0, 0, 0.4);
            display: flex;
            flex-direction: column;
            justify-content: space-between;
            align-items: center;
            padding: 20px 0;
            transition: all 0.5s ease;
            position: relative;
            transform-origin: bottom center;
        }

        .book-spine:hover {
            transform: translateY(-20px) scale(1.05);
            box-shadow: 0 15px 25px rgba(212, 175, 55, 0.5);
            border-color: #fff;
        }

        .spine-title {
            writing-mode: vertical-rl;
            text-orientation: mixed;
            color: var(--psut-gold);
            font-weight: bold;
            font-size: 1.1rem;
            letter-spacing: 2px;
        }

        .spine-logo {
            width: 30px;
            height: 30px;
            border: 1px solid var(--psut-gold);
            border-radius: 50%;
            display: flex;
            align-items: center;
            justify-content: center;
            color: gold;
            font-size: 10px;
            font-weight: bold;
        }

        /* حالة إخفاء باقي الكتب عند الاختيار */
        .bookshelf.active .book-spine:not(.selected) {
            opacity: 0;
            transform: scale(0.5) translateY(100px);
            pointer-events: none;
        }

        .book-spine.selected {
            animation: liftAndFlip 0.8s forwards ease-in-out;
            opacity: 0;
        }

        @keyframes liftAndFlip {
            0% { transform: translateY(0) rotate(0deg); opacity: 1; }
            50% { transform: translateY(-150px) rotate(180deg) scale(1.2); opacity: 0.8; }
            100% { transform: translateY(-300px) rotate(360deg) scale(0); opacity: 0; }
        }

        /* نافذة الكتاب المفتوح (Real Open Book) */
        .open-book-modal {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%) scale(0);
            width: 850px;
            height: 520px;
            background: #fff8eb;
            border: 8px solid #3d2314;
            border-radius: 12px;
            box-shadow: 0 30px 60px rgba(0, 0, 0, 0.6);
            display: flex;
            opacity: 0;
            transition: all 0.6s cubic-bezier(0.175, 0.885, 0.32, 1.275);
            z-index: 100;
            direction: ltr; /* لترتيب الصفحات يمين ويسار */
        }

        .open-book-modal.show {
            transform: translate(-50%, -50%) scale(1);
            opacity: 1;
        }

        /* خط المنتصف (فاصل الصفحات) */
        .open-book-modal::after {
            content: '';
            position: absolute;
            top: 0;
            bottom: 0;
            left: 50%;
            width: 4px;
            background: linear-gradient(to right, rgba(0,0,0,0.25), rgba(0,0,0,0.05), rgba(0,0,0,0.25));
            transform: translateX(-50%);
        }

        /* صفحة الكتاب */
        .book-page {
            width: 50%;
            height: 100%;
            padding: 40px 30px;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            box-sizing: border-box;
            position: relative;
        }

        /* الصفحة اليسرى (الصورة والتخصص) */
        .page-left {
            border-right: 1px solid #e0d7c6;
            background: #faf4e8;
        }

        .profile-img-container {
            width: 170px;
            height: 170px;
            border-radius: 50%;
            border: 5px solid var(--psut-navy);
            box-shadow: 0 8px 20px rgba(0,0,0,0.2);
            overflow: hidden;
            margin-bottom: 20px;
        }

        .profile-img-container img {
            width: 100%;
            height: 100%;
            object-fit: cover;
        }

        .member-name {
            color: var(--psut-navy);
            font-size: 1.6rem;
            font-weight: bold;
            margin-bottom: 5px;
            text-align: center;
        }

        .member-major {
            color: #666;
            font-size: 1rem;
            font-weight: 600;
        }

        /* الصفحة اليمنى (المعلومات والمقولة) */
        .page-right {
            background: #fff8eb;
            align-items: flex-start;
            text-align: left;
        }

        .section-title {
            color: var(--psut-navy);
            font-size: 1.1rem;
            font-weight: bold;
            border-bottom: 2px solid var(--psut-gold);
            padding-bottom: 4px;
            margin-bottom: 12px;
            width: 100%;
        }

        .role-badge {
            background-color: var(--psut-navy);
            color: white;
            padding: 6px 14px;
            border-radius: 20px;
            font-size: 0.9rem;
            margin-bottom: 25px;
            display: inline-block;
        }

        .quote-box {
            font-style: italic;
            color: #444;
            background: #f0e6d2;
            border-left: 4px solid var(--psut-gold);
            padding: 12px 15px;
            border-radius: 4px;
            margin-bottom: 25px;
            font-size: 0.95rem;
            line-height: 1.4;
            width: 100%;
        }

        .portfolio-links {
            display: flex;
            gap: 15px;
            width: 100%;
        }

        .btn-link {
            text-decoration: none;
            color: white;
            background: var(--psut-blue);
            padding: 8px 16px;
            border-radius: 6px;
            font-size: 0.85rem;
            font-weight: bold;
            transition: 0.3s;
        }

        .btn-link:hover {
            background: var(--psut-navy);
            transform: translateY(-2px);
        }

        /* زر إغلاق الكتاب */
        .close-btn {
            position: absolute;
            top: 15px;
            right: 20px;
            background: var(--psut-navy);
            color: white;
            border: none;
            width: 35px;
            height: 35px;
            border-radius: 50%;
            font-size: 18px;
            cursor: pointer;
            z-index: 105;
            transition: 0.3s;
        }

        .close-btn:hover {
            background: #c0392b;
            transform: rotate(90deg);
        }
    </style>
</head>
<body>

    <div class="stage">
        <!-- رف الكتب -->
        <div class="bookshelf" id="bookshelf">
            <!-- سيتم توليد الـ 7 كتب تلقائياً بواسطة JavaScript -->
        </div>

        <!-- الكتاب المفتوح (نافذة العرض) -->
        <div class="open-book-modal" id="openBook">
            <button class="close-btn" onclick="closeBook()">✕</button>

            <!-- الصفحة اليسرى: الصورة والاسم -->
            <div class="book-page page-left">
                <div class="profile-img-container">
                    <img id="bookImg" src="" alt="صورة الطالب">
                </div>
                <div class="member-name" id="bookName">اسم الطالب</div>
                <div class="member-major" id="bookMajor">التخصص الجامعي</div>
            </div>

            <!-- الصفحة اليمنى: التفاصيل والمقولة -->
            <div class="book-page page-right">
                <div class="section-title">المهمة والفي مشروع UIMS</div>
                <div class="role-badge" id="bookRole">الدور الموكل له</div>

                <div class="section-title">المقولة المفضلة (Quote)</div>
                <div class="quote-box" id="bookQuote">"المقولة المفضلة للطالب تفهرس هنا..."</div>

                <div class="section-title">روابط الأعمال</div>
                <div class="portfolio-links">
                    <a href="#" class="btn-link" id="linkPortfolio" target="_blank">Portfolio</a>
                    <a href="#" class="btn-link" id="linkGithub" target="_blank">GitHub</a>
                    <a href="#" class="btn-link" id="linkLinkedin" target="_blank">LinkedIn</a>
                </div>
            </div>
        </div>
    </div>

    <script>
        // بيانات الطلاب السبعة
        const teamMembers = [
            { id: 1, name: "SARIAH KALMAN", major: "Software Engineering", role: "Frontend Developer", quote: "Code is like humor. When you have to explain it, it’s bad.", img: "https://images.unsplash.com/photo-1534528741775-53994a69daeb?w=400" },
            { id: 2, name: "BACKENZI RAMADED", major: "Computer Science", role: "Backend & Firebase", quote: "Simplicity is the soul of efficiency.", img: "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=400" },
            { id: 3, name: "SADIAH MARKAR", major: "Computer Science", role: "UI/UX Designer", quote: "Design is not just what it looks like. Design is how it works.", img: "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=400" },
            { id: 4, name: "MIRRANCI SAKAUBAR", major: "Computer Science", role: "QA Specialist", quote: "Quality is not an act, it is a habit.", img: "https://images.unsplash.com/photo-1517841905240-472988babdf9?w=400" },
            { id: 5, name: "HAMZA AWAD", major: "Software Engineering", role: "Database Specialist", quote: "Data is the new oil of the digital economy.", img: "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?w=400" },
            { id: 6, name: "ACADEMIC SUPERVISOR", major: "PSUT IT Faculty", role: "Academic Supervisor", quote: "Guidance and knowledge shape the future of technology.", img: "https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?w=400" },
            { id: 7, name: "INTERNSHIP COORDINATOR", major: "PSUT IT Faculty", role: "University Internship Coordinator", quote: "Connecting academic excellence with industry innovation.", img: "https://images.unsplash.com/photo-1573496359142-b8d87734a5a2?w=400" }
        ];

        const bookshelf = document.getElementById('bookshelf');
        const openBookModal = document.getElementById('openBook');

        // إنشاء الكتب السبعة على الرف
        teamMembers.forEach((member) => {
            const book = document.createElement('div');
            book.className = 'book-spine';
            book.innerHTML = `
                <div class="spine-logo">PSUT</div>
                <div class="spine-title">${member.name}</div>
                <div class="spine-logo">IT</div>
            `;
            book.onclick = () => selectBook(book, member);
            bookshelf.appendChild(book);
        });

        // عند اختيار أي كتاب
        function selectBook(selectedBook, memberData) {
            // 1. تفعيل إخفاء الكتب الأخرى
            bookshelf.classList.add('active');
            selectedBook.classList.add('selected');

            // 2. تعبئة بيانات الكتاب المفتوح
            document.getElementById('bookImg').src = memberData.img;
            document.getElementById('bookName').innerText = memberData.name;
            document.getElementById('bookMajor').innerText = memberData.major;
            document.getElementById('bookRole').innerText = memberData.role;
            document.getElementById('bookQuote').innerText = `"${memberData.quote}"`;

            // 3. فتح الكتاب بعد انتهاء الحركة
            setTimeout(() => {
                openBookModal.classList.add('show');
            }, 600);
        }

        // إغلاق الكتاب وإعادة الرف كما كان
        function closeBook() {
            openBookModal.classList.remove('show');
            setTimeout(() => {
                bookshelf.classList.remove('active');
                document.querySelectorAll('.book-spine').forEach(b => {
                    b.classList.remove('selected');
                });
            }, 400);
        }
    </script>
</body>
</html>
