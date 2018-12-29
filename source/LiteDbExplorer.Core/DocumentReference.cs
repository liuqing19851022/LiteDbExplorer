﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using LiteDB;

namespace LiteDbExplorer
{
    public class DocumentReference : INotifyPropertyChanged
    {
        private BsonDocument _liteDocument;
        private CollectionReference _collection;

        public DocumentReference()
        {
            InstanceId = Guid.NewGuid().ToString();
        }

        public DocumentReference(BsonDocument document, CollectionReference collection) : this()
        {
            LiteDocument = document;
            Collection = collection;
        }

        public string InstanceId { get; }

        public BsonDocument LiteDocument
        {
            get => _liteDocument;
            set
            {
                if (Equals(value, _liteDocument)) return;
                _liteDocument = value;
                OnPropertyChanged();
            }
        }

        public CollectionReference Collection
        {
            get => _collection;
            set
            {
                if (Equals(value, _collection)) return;
                _collection = value;
                OnPropertyChanged();
            }
        }

        [UsedImplicitly]
        public event PropertyChangedEventHandler PropertyChanged;

        public void InvalidateProperties()
        {
            OnPropertyChanged(string.Empty);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}